using Services.DAL.Factories;
using SDM = Services.DomainModel;
using System;
using System.Configuration;

namespace Services.BLL
{
    internal static class LoggerBLL
    {
        private static SDM.Severity _minSeverity = SDM.Severity.Info;

        static LoggerBLL()
        {
            try
            {
                var cfg = ConfigurationManager.AppSettings["MinLogSeverity"] ?? "Info";
                SDM.Severity s;
                if (Enum.TryParse(cfg, true, out s))
                    _minSeverity = s;
            }
            catch
            {
                _minSeverity = SDM.Severity.Info;
            }
        }

        // Single public method using LoggerRepository as canonical sink
        public static void Write(SDM.Severity severity, string message, string user = "")
        {
            try
            {
                if (severity < _minSeverity)
                    return; // filtered out by policy

                // Write to repository (single canonical implementation)
                try
                {
                    if (ServiceFactory.LoggerRepository != null)
                    {
                        ServiceFactory.LoggerRepository.WriteLog(severity, message, user);
                    }
                }
                catch
                {
                    // swallow repository failures
                }
            }
            catch
            {
                // swallow
            }
        }
    }
}
