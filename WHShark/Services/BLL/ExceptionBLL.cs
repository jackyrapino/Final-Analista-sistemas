using Services.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{
    internal static class ExceptionBLL
    {
       
        public static void Handle(Exception ex, object sender)
        {
            // Apply policies for exceptions
            Console.WriteLine(ex.Message);

            // If the exception has an inner exception, assume it originated in DAL
            if (ex.InnerException != null)
            {
                DALPolicy(ex);
            }
            else
            {
                BLLPolicy(ex);
            }
        }

        private static void DALPolicy(Exception ex)
        {
            // 1) Log
            try
            {
                LoggerService.WriteError(string.Format("Message; {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
            }
            catch
            {
                // swallow logging errors
            }

            // 2) Wrap and propagate
            throw new Exception(string.Empty, ex);
        }

        private static void BLLPolicy(Exception ex)
        {
            // For BLL-originated exceptions, log and rethrow with a business-layer message
            try
            {
                LoggerService.WriteError(string.Format("Message; {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
            }
            catch
            {
                // swallow
            }

            throw new Exception("Error en la capa de negocio", ex);
        }
    }
}
