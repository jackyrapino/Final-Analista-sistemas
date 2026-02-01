using Services.DAL.Factories;
using SDM = Services.DomainModel;
using System;
using System.Configuration;
using System.Diagnostics.Tracing;

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

                // Map domain Severity to EventLevel used by repository
                EventLevel evt = severity == SDM.Severity.FatalError || severity == SDM.Severity.CriticalError
                    ? EventLevel.Critical
                    : (severity == SDM.Severity.Error ? EventLevel.Error
                        : (severity == SDM.Severity.Warning ? EventLevel.Warning : EventLevel.Informational));

                // Write to repository (single canonical implementation)
                try
                {
                    if (ServiceFactory.LoggerRepository != null)
                    {
                        ServiceFactory.LoggerRepository.WriteLog(message, evt, user);
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
