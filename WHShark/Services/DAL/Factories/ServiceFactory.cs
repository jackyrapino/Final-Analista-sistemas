using Services.DAL.Implementations;
using Services.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Services.DAL.Factories
{
    internal static class ServiceFactory
    {
        public static LanguageRepository LanguageRepository { get; private set; }

        // Keep LoggerRepository as the canonical logging repository
        public static LoggerRepository LoggerRepository { get; private set; }

        static ServiceFactory()
        {
            // Inicializar las instancias de los repositorios
            LanguageRepository = LanguageRepository.Current;
            LoggerRepository = LoggerRepository.Current;
        }

    }
}
