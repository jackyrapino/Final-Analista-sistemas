using System.Threading;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    internal interface IBackupRepository
    {
        Task<string> BackupAsync(string backupFolder, string backupName = null, bool copyOnly = true, CancellationToken ct = default);

        Task RestoreAsync(string backupFileFullPath, bool withReplace = false, string dataDir = null, string logDir = null, CancellationToken ct = default);

        Task VerifyAsync(string backupFileFullPath, CancellationToken ct = default);
    }
}
