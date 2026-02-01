using Services.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDM = Services.DomainModel;

namespace Services.BLL
{
    internal static class ExceptionBLL
    {
        private static string dalAssembly = ConfigurationManager.AppSettings["DALAssembly"];
        private static string bllAssembly = ConfigurationManager.AppSettings["BLLAssembly"];

        public static void Handle(Exception ex, object sender)
        {
            //Aplicar nuestras políticas de Exceptions
            Console.WriteLine(ex.Message);

            string assemblyName = sender.GetType().Module.Name;

            if (assemblyName == dalAssembly)
            {
                //Aplicamos la política de exception de la DAL
                DALPolicy(ex, sender);
            }
            else if (assemblyName == bllAssembly)
            {
                BLLPolicy(ex, sender);
            }
        }

        private static void DALPolicy(Exception ex, object sender)
        {
            //1) Registrar - incluir tipo que generó la excepción como usuario
            string user = sender?.GetType().Name ?? string.Empty;
            LoggerService.WriteError(string.Format("Message; {0}, StackTrace: {1}", ex.Message, ex.StackTrace), user);
            //2) Propagar
            throw new Exception(string.Empty, ex);
        }

        private static void BLLPolicy(Exception ex, object sender)
        {
            //Tengo que saber si la exception viene de BLL puramente o de DAL
            if (ex.InnerException != null)
            {
                //Estoy ante una exception en BLL pero que fue originada en DAL
                throw new Exception("Error accediendo a los datos...", ex);
            }
            else
            {
                //Es una exception propia de BLL
                string user = sender?.GetType().Name ?? string.Empty;
                LoggerService.WriteError(string.Format("Message; {0}, StackTrace: {1}", ex.Message, ex.StackTrace), user);
                //2) Propagar
                throw ex;
            }
        }
    }
}
