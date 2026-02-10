using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.DAL.Implementations;
using Services.DAL.Contracts;

namespace Services.Services
{
    /// <summary>
    /// Simple facade for UI: backup/restore operations for both Business and Auth databases.
    /// The user triggers a single "Backup" or "Restore" action; internally both databases are handled.
    /// </summary>
    public static class BackupService
    {
        private const string BusinessConnection = "ManagerBusiness";
        private const string AuthConnection = "ManagerAuth";

        private static IBackupRepository CreateRepositoryFor(string connectionName)
        {
            var cs = ConfigurationManager.ConnectionStrings[connectionName];
            if (cs == null)
                throw new ConfigurationErrorsException($"Connection string '{connectionName}' not found in configuration.");

            return new BackupRepository(cs.ConnectionString);
        }

        /// <summary>
        /// Creates backups for both databases (Business + Auth). Returns the Business backup path for compatibility.
        /// </summary>
        public static string BackupDatabase(string folderPath, string backupFileName = null)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                throw new ArgumentException("Destination folder cannot be empty.", nameof(folderPath));

            var result = BackupBoth(folderPath, businessBackupName: backupFileName, authBackupName: null, copyOnly: true);
            return result.BusinessBackupPath;
        }

        /// <summary>
        /// Restores both databases from a folder that contains the .bak files.
        /// The two most recent .bak files in the folder are used.
        /// </summary>
        public static void RestoreDatabase(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                throw new ArgumentException("Invalid backup path.", nameof(folderPath));

            if (!Directory.Exists(folderPath))
                throw new ArgumentException("The specified path is not a valid folder.", nameof(folderPath));

            // Find .bak files in the folder and take the two most recent
            var files = Directory.GetFiles(folderPath, "*.bak")
                                 .OrderByDescending(f => File.GetCreationTimeUtc(f))
                                 .ToArray();

            if (files.Length == 0)
                throw new FileNotFoundException("No .bak files found in the specified folder.");

            string first = files[0];
            string second = files.Length > 1 ? files[1] : null;

            // Execute sequential restore (safer)
            RestoreBoth(first, second, withReplace: true, parallel: false);
        }

        /// <summary>
        /// Performs backups in parallel for Business and Auth and returns the generated file paths.
        /// </summary>
        public static (string BusinessBackupPath, string AuthBackupPath) BackupBoth(string folderPath, string businessBackupName = null, string authBackupName = null, bool copyOnly = true)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                throw new ArgumentException("Destination folder cannot be empty.", nameof(folderPath));

            var repoBiz = CreateRepositoryFor(BusinessConnection);
            var repoAuth = CreateRepositoryFor(AuthConnection);

            var tBiz = repoBiz.BackupAsync(folderPath, businessBackupName, copyOnly, CancellationToken.None);
            var tAuth = repoAuth.BackupAsync(folderPath, authBackupName, copyOnly, CancellationToken.None);

            Task.WaitAll(tBiz, tAuth);

            return (tBiz.GetAwaiter().GetResult(), tAuth.GetAwaiter().GetResult());
        }

        /// <summary>
        /// Restores both databases. By default restores sequentiall.
        /// </summary>
        public static void RestoreBoth(string businessBackupPath, string authBackupPath, bool withReplace = true, bool parallel = false,
                                       string businessDataDir = null, string businessLogDir = null, string authDataDir = null, string authLogDir = null)
        {
            if (string.IsNullOrWhiteSpace(businessBackupPath) && string.IsNullOrWhiteSpace(authBackupPath))
                throw new ArgumentException("At least one backup path must be provided.");

            var repoBiz = CreateRepositoryFor(BusinessConnection);
            var repoAuth = CreateRepositoryFor(AuthConnection);

            if (parallel)
            {
                var tBiz = string.IsNullOrWhiteSpace(businessBackupPath)
                    ? Task.CompletedTask
                    : repoBiz.RestoreAsync(businessBackupPath, withReplace, businessDataDir, businessLogDir, CancellationToken.None);

                var tAuth = string.IsNullOrWhiteSpace(authBackupPath)
                    ? Task.CompletedTask
                    : repoAuth.RestoreAsync(authBackupPath, withReplace, authDataDir, authLogDir, CancellationToken.None);

                Task.WaitAll(tBiz, tAuth);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(businessBackupPath))
                    repoBiz.RestoreAsync(businessBackupPath, withReplace, businessDataDir, businessLogDir, CancellationToken.None).GetAwaiter().GetResult();

                if (!string.IsNullOrWhiteSpace(authBackupPath))
                    repoAuth.RestoreAsync(authBackupPath, withReplace, authDataDir, authLogDir, CancellationToken.None).GetAwaiter().GetResult();
            }
        }

        /// <summary>
        /// Verifies both backup files in parallel using RESTORE VERIFYONLY.
        /// </summary>
        public static void VerifyBoth(string businessBackupPath, string authBackupPath)
        {
            if (string.IsNullOrWhiteSpace(businessBackupPath) && string.IsNullOrWhiteSpace(authBackupPath))
                throw new ArgumentException("At least one backup path must be provided.");

            var repoBiz = CreateRepositoryFor(BusinessConnection);
            var repoAuth = CreateRepositoryFor(AuthConnection);

            var tBiz = string.IsNullOrWhiteSpace(businessBackupPath)
                ? Task.CompletedTask
                : repoBiz.VerifyAsync(businessBackupPath, CancellationToken.None);

            var tAuth = string.IsNullOrWhiteSpace(authBackupPath)
                ? Task.CompletedTask
                : repoAuth.VerifyAsync(authBackupPath, CancellationToken.None);

            Task.WaitAll(tBiz, tAuth);
        }
    }
}
