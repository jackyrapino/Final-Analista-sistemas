using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Services.DAL.Contracts;

namespace Services.DAL.Implementations
{
    /// <summary>
    /// SQL Server implementation of the backup and restore repository.
    /// </summary>
    internal class BackupRepository : IBackupRepository
    {
        private readonly string _cs;
        private readonly string _csMaster;

        /// <summary>
        /// Initializes the repository and prepares a connection string to master.
        /// </summary>
        public BackupRepository(string cs)
        {
            if (string.IsNullOrWhiteSpace(cs))
                throw new ArgumentNullException(nameof(cs));

            _cs = cs;
            var b = new SqlConnectionStringBuilder(cs) { InitialCatalog = "master" };
            _csMaster = b.ConnectionString;
        }

        /// <summary>
        /// Creates a .bak file for the configured database. Returns the full path to the created file.
        /// </summary>
        public async Task<string> BackupAsync(string backupFolder, string backupName = null, bool copyOnly = true, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(backupFolder))
                throw new ArgumentException("Backup folder is empty.", nameof(backupFolder));

            Directory.CreateDirectory(backupFolder);

            var dbName = new SqlConnectionStringBuilder(_cs).InitialCatalog;
            var ts = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"{(string.IsNullOrWhiteSpace(backupName) ? dbName : backupName)}_{ts}.bak";
            var fullPath = Path.Combine(backupFolder, fileName);

            var sql = $"BACKUP DATABASE [{dbName}] TO DISK=@p0 WITH {(copyOnly ? "COPY_ONLY," : "")} INIT, STATS=5;";

            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(sql, cn) { CommandTimeout = 0 })
            {
                cmd.Parameters.AddWithValue("@p0", fullPath);
                await cn.OpenAsync(ct).ConfigureAwait(false);
                await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
            }

            return fullPath;
        }

        /// <summary>
        /// Attempts to set the restored database back to MULTI_USER. This helper will swallow exceptions
        /// because failure here should not hide the original restore exception.
        /// </summary>
        private async Task EnsureMultiUserAsync(string setMulti, CancellationToken ct)
        {
            try
            {
                using (var cn = new SqlConnection(_csMaster))
                using (var cmd = new SqlCommand(setMulti, cn) { CommandTimeout = 0 })
                {
                    await cn.OpenAsync(ct).ConfigureAwait(false);
                    await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                }
            }
            catch
            {
                // Intentionally swallow exceptions to not mask original restore errors.
            }
        }

        /// <summary>
        /// Restores the configured database from the supplied .bak file. Supports optional MOVE behavior
        /// when dataDir/logDir are provided.
        /// </summary>
        public async Task RestoreAsync(string backupFileFullPath, bool withReplace = false, string dataDir = null, string logDir = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(backupFileFullPath))
                throw new ArgumentException("Backup file path is empty.", nameof(backupFileFullPath));

            if (!File.Exists(backupFileFullPath))
                throw new FileNotFoundException("Backup file not found.", backupFileFullPath);

            var dbName = new SqlConnectionStringBuilder(_cs).InitialCatalog;

            var setSingle = $"IF DB_ID('{dbName}') IS NOT NULL ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            var setMulti = $"ALTER DATABASE [{dbName}] SET MULTI_USER;";

            // If no MOVE directories provided, perform a normal RESTORE
            if (string.IsNullOrWhiteSpace(dataDir) || string.IsNullOrWhiteSpace(logDir))
            {
                var restoreSql = $@"
                                    RESTORE DATABASE [{dbName}]
                                    FROM DISK=@p0
                                    WITH STATS=5{(withReplace ? ", REPLACE" : "")};";

                using (var cn = new SqlConnection(_csMaster))
                using (var cmd = new SqlCommand(setSingle + restoreSql, cn) { CommandTimeout = 0 })
                {
                    cmd.Parameters.AddWithValue("@p0", backupFileFullPath);
                    await cn.OpenAsync(ct).ConfigureAwait(false);

                    try
                    {
                        await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                    }
                    finally
                    {
                        await EnsureMultiUserAsync(setMulti, ct).ConfigureAwait(false);
                    }
                }

                return;
            }

            // When MOVE is required, ensure target directories exist
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(logDir);

            string logicalData = null, logicalLog = null;

            // Read logical file names from the backup
            using (var cn = new SqlConnection(_csMaster))
            using (var cmd = new SqlCommand("RESTORE FILELISTONLY FROM DISK=@p0;", cn) { CommandTimeout = 0 })
            {
                cmd.Parameters.AddWithValue("@p0", backupFileFullPath);
                await cn.OpenAsync(ct).ConfigureAwait(false);

                using (var rd = await cmd.ExecuteReaderAsync(ct).ConfigureAwait(false))
                {
                    while (await rd.ReadAsync(ct).ConfigureAwait(false))
                    {
                        var type = rd["Type"].ToString();
                        var name = rd["LogicalName"].ToString();

                        if (type == "D" && logicalData == null) logicalData = name;
                        if (type == "L" && logicalLog == null) logicalLog = name;
                    }
                }
            }

            logicalData = logicalData ?? dbName;
            logicalLog = logicalLog ?? (dbName + "_log");

            var dataPath = Path.Combine(dataDir, dbName + ".mdf");
            var logPath = Path.Combine(logDir, dbName + "_log.ldf");

            var restoreMoveSql = $@"
                                    RESTORE DATABASE [{dbName}]
                                    FROM DISK=@p0
                                    WITH MOVE @p1 TO @p2,
                                    MOVE @p3 TO @p4,
                                    STATS=5{(withReplace ? ", REPLACE" : "")};";

            using (var cn = new SqlConnection(_csMaster))
            using (var cmd = new SqlCommand(setSingle + restoreMoveSql, cn) { CommandTimeout = 0 })
            {
                cmd.Parameters.AddWithValue("@p0", backupFileFullPath);
                cmd.Parameters.AddWithValue("@p1", logicalData);
                cmd.Parameters.AddWithValue("@p2", dataPath);
                cmd.Parameters.AddWithValue("@p3", logicalLog);
                cmd.Parameters.AddWithValue("@p4", logPath);

                await cn.OpenAsync(ct).ConfigureAwait(false);

                try
                {
                    await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                }
                finally
                {
                    await EnsureMultiUserAsync(setMulti, ct).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Verifies the backup file using RESTORE VERIFYONLY.
        /// </summary>
        public async Task VerifyAsync(string backupFileFullPath, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(backupFileFullPath))
                throw new ArgumentException("Backup file path is empty.", nameof(backupFileFullPath));

            if (!File.Exists(backupFileFullPath))
                throw new FileNotFoundException("Backup file not found.", backupFileFullPath);

            using (var cn = new SqlConnection(_csMaster))
            using (var cmd = new SqlCommand("RESTORE VERIFYONLY FROM DISK=@p0;", cn) { CommandTimeout = 0 })
            {
                cmd.Parameters.AddWithValue("@p0", backupFileFullPath);
                await cn.OpenAsync(ct).ConfigureAwait(false);
                await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
            }
        }
    }
}
