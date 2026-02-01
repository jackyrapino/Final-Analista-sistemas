using System;
using System.Diagnostics.Tracing;
using Services.DomainModel;
using Services.BLL;

namespace Services.Services
{
    public static class LoggerService
    {
        public static void WriteLog(string message, EventLevel level, string user)
        {
            var severity = MapEventLevelToSeverity(level);
            LoggerBLL.Write(severity, message, user);
        }

        public static void Log(Severity severity, string message)
        {
            LoggerBLL.Write(severity, message);
        }

        public static void LogInfo(string message) => Log(Severity.Info, message);
        public static void LogWarning(string message) => Log(Severity.Warning, message);
        public static void LogError(string message) => Log(Severity.Error, message);

        private static global::Services.DomainModel.Severity MapEventLevelToSeverity(EventLevel level)
        {
            switch (level)
            {
                case EventLevel.Critical:
                    return global::Services.DomainModel.Severity.FatalError;
                case EventLevel.Error:
                    return global::Services.DomainModel.Severity.Error;
                case EventLevel.Warning:
                    return global::Services.DomainModel.Severity.Warning;
                case EventLevel.Informational:
                case EventLevel.Verbose:
                default:
                    return global::Services.DomainModel.Severity.Info;
            }
        }
    }
}
