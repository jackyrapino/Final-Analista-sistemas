using System;
using System.Configuration;
using System.Threading;
using Services.DAL.Implementations;
using Services.DAL.Contracts;

namespace Services.Services
{
    /// <summary>
    /// Facade para UI: expone operaciones de backup/restore pero delega la lógica al BackupRepository (DAL).
    /// Mantiene la compatibilidad sincrónica con la UI; internamente utiliza los métodos async del repositorio.
    /// </summary>
    public static class BackupService
    {
        private const string ConnectionName = "ManagerBusiness";

        private static IBackupRepository CreateRepository()
        {
            var cs = ConfigurationManager.ConnectionStrings[ConnectionName];
            if (cs == null)
                throw new ConfigurationErrorsException($"Connection string '{ConnectionName}' not found in configuration.");

            return new BackupRepository(cs.ConnectionString);
        }

        public static string BackupDatabase(string folderPath, string backupFileName = null)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                throw new ArgumentException("El folder de destino no puede ser vacío", nameof(folderPath));

            try
            {
                var repo = CreateRepository();
                // Ejecutar el método async de forma síncrona para mantener compatibilidad con la UI existente
                return repo.BackupAsync(folderPath, backupFileName, copyOnly: true, ct: CancellationToken.None)
                           .GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Error realizando backup: {ex.Message}");
                throw;
            }
        }

        public static void RestoreDatabase(string backupFilePath)
        {
            if (string.IsNullOrWhiteSpace(backupFilePath))
                throw new ArgumentException("Ruta de backup inválida", nameof(backupFilePath));

            try
            {
                var repo = CreateRepository();
                repo.RestoreAsync(backupFilePath, withReplace: true, dataDir: null, logDir: null, ct: CancellationToken.None)
                    .GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"Error realizando restore: {ex.Message}");
                throw;
            }
        }
    }
}
