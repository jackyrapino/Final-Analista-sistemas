using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.Security
{
    public enum UserState
    {
        ForceChange = 0,
        Active = 1,
        Inactive = 2,
        Blocked = 3
    }

    internal class User
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
