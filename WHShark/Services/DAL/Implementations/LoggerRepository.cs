using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations
{
    internal sealed class LoggerRepository
    {
        #region Singleton
        private readonly static LoggerRepository _instance = new LoggerRepository();

        public static LoggerRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerRepository()
        {
            //Implement here the initialization code
            // Ensure path settings have safe defaults
            if (string.IsNullOrWhiteSpace(pathLog))
                pathLog = AppDomain.CurrentDomain.BaseDirectory;
            if (string.IsNullOrWhiteSpace(pathFile))
                pathFile = "_app.log";
        }
        #endregion

        private string pathLog = ConfigurationManager.AppSettings["PathLog"];

        private string pathFile = ConfigurationManager.AppSettings["LogFileName"];

        // New signature: use domain Severity and user string
        public void WriteLog(global::Services.DomainModel.Severity severity, string message, string user)
        {
            try
            {
                // Ensure directory exists
                string directory = pathLog;
                if (string.IsNullOrWhiteSpace(directory))
                    directory = AppDomain.CurrentDomain.BaseDirectory;

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                // Build filename: yyyyMMdd + pathFile (which can include extension)
                string fileName = Path.Combine(directory, DateTime.Now.ToString("yyyyMMdd") + pathFile);

                // Ensure file exists and then append line
                using (StreamWriter streamWriter = new StreamWriter(fileName, true, System.Text.Encoding.UTF8))
                {
                    string ts = DateTime.UtcNow.ToString("o"); // ISO 8601
                    string line = $"{ts} [{severity}] User:{user} {message}";
                    streamWriter.WriteLine(line);
                }
            }
            catch
            {
                // swallow IO exceptions - do not throw from logger
            }
        }
    }
}
