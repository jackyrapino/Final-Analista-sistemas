using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.Security.Composite
{
    public class User
    {
        public string Name { get; set; }

        // Stored password is expected to be the hashed value
        public string Password { get; set; }

        // Authentication/management fields
        public int FailedAttempts { get; set; }
        public global::Services.DomainModel.Security.UserState State { get; set; }

        public string PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpires { get; set; }

        public string HashDH
        {
            get
            {
                return CryptographyService.HashPassword(Name + Password);
            }
        }

        public string HashPassword
        {
            get
            {
                return CryptographyService.HashPassword(this.Password);
            }
        }

        public List<Component> Permisos { get; set; }

        public User()
        {
            Permisos = new List<Component>();
            FailedAttempts = 0;
            State = global::Services.DomainModel.Security.UserState.Active;
        }

        /// <summary>
        /// Retornar las patentes únicas de acuerdo a mi modelo
        /// (Para el armado del menú)
        /// </summary>
        /// <returns></returns>
        public List<Patent> GetPatentesAll()
        {
            List<Patent> patentsDistinct = new List<Patent>();

            RecorrerComposite(patentsDistinct, Permisos, "-");

            return patentsDistinct;
        }

        private static void RecorrerComposite(List<Patent> patents, List<Component> components, string tab)
        {
            foreach (var item in components)
            {
                if (item.ChildrenCount() == 0)
                {
                    //Estoy ante un elemento de tipo Patente
                    Patent patente1 = item as Patent;
                    Console.WriteLine($"{tab} Patente: {patente1.FormName}");

                    if (!patents.Exists(o => o.FormName == patente1.FormName))
                        patents.Add(patente1);
                }
                else
                {
                    Family familia = item as Family;
                    Console.WriteLine($"{tab} Familia: {familia.Nombre}");
                    RecorrerComposite(patents, familia.GetChildrens(), tab + "-");
                }
            }
        }

    }
}
