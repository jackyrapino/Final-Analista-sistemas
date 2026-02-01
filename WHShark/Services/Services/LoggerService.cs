using System;
using System.Diagnostics.Tracing;
using Services.BLL;
using Services.DomainModel;

namespace Services.Services
{
    public static class LoggerService
    {
        // Explicit methods per severity for clarity
        public static void WriteInfo(string message, string user = "")
        {
            LoggerBLL.Write(Severity.Info, message, user);
        }

        public static void WriteWarning(string message, string user = "")
        {
            LoggerBLL.Write(Severity.Warning, message, user);
        }

        public static void WriteError(string message, string user = "")
        {
            LoggerBLL.Write(Severity.Error, message, user);
        }

        public static void WriteCriticalError(string message, string user = "")
        {
            LoggerBLL.Write(Severity.CriticalError, message, user);
        }

        public static void WriteFatalError(string message, string user = "")
        {
            LoggerBLL.Write(Severity.FatalError, message, user);
        }
    }
}
