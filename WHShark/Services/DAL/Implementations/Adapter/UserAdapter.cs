using Services.DAL.Contracts;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.Adapter
{
    public sealed class UserAdapter : IAdapter<User>
    {
        #region Singleton
        private readonly static UserAdapter _instance = new UserAdapter();

        public static UserAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private UserAdapter()
        {
            //Implement here the initialization code
        }
        #endregion
        public User Adapt(object[] values)
        {
            //Hidratar el objeto familia -> Nivel 1
            /*Usuario usuario = new Usuario()
            {
                idUsuario = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString()
            };


            //Nivel 2 de hidratación...
            UsuarioFamiliaRepository.Current.GetChildren(usuario);
            UsuarioPatenteRepository.Current.GetChildren(usuario);

            return usuario;*/
            return null;
        }
    }
}
