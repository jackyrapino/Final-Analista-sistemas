using System.Threading;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Repository interface for performing database backup/restore operations against SQL Server.
    /// </summary>
    internal interface IBackupRepository
    {
        /// <summary>
        /// Creates a backup file for the configured database.
        /// </summary>
        Task<string> BackupAsync(string backupFolder, string backupName = null, bool copyOnly = true, CancellationToken ct = default);

        /// <summary>
        /// Restores a database from a backup file. Optionally supports MOVE for relocating files.
        /// </summary>
        Task RestoreAsync(string backupFileFullPath, bool withReplace = false, string dataDir = null, string logDir = null, CancellationToken ct = default);

        /// <summary>
        /// Verifies the integrity of a backup file using RESTORE VERIFYONLY.
        /// </summary>
        Task VerifyAsync(string backupFileFullPath, CancellationToken ct = default);
    }
}
