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
        }
        #endregion

        private string pathLog = ConfigurationManager.AppSettings["PathLog"];

        private string pathFile = ConfigurationManager.AppSettings["LogFileName"];

        // New signature: use domain Severity and user string
        public void WriteLog(global::Services.DomainModel.Severity severity, string message, string user)
        {
            string fileName = pathLog + DateTime.Now.ToString("yyyyMMdd") + pathFile;

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName, true, System.Text.Encoding.UTF8))
                {
                    string ts = DateTime.UtcNow.ToString("o"); // ISO 8601
                    string line = $"{ts} [{severity}] User:{user} {message}";
                    streamWriter.WriteLine(line);
                }
            }
            catch
            {
                // swallow IO exceptions
            }
        }
    }
}
