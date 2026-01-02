using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.Security
{
    internal class Usuario
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Family> Families { get; set; }

        public List<Patent> Patents { get; set; }


        /// <summary>
        /// Retornar las patentes únicas de acuerdo a mi modelo
        /// (Para el armado del menú)
        /// </summary>
        /// <returns></returns>
        public List<Patent> GetPatentesAll()
        {
            return null;
        }


    }
}
