using Services.DAL.Contracts;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.Adapter
{
    public sealed class FamilyAdapter : IAdapter<Family>
    {
        #region Singleton
        private readonly static FamilyAdapter _instance = new FamilyAdapter();

        public static FamilyAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private FamilyAdapter()
        {
            //Implement here the initialization code
        }
        #endregion
        public Family Adapt(object[] values)
        {
            //Hidratar el objeto familia -> Nivel 1
            Family family = new Family()
            {
                IdComponent = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString()
            };


            //Nivel 2 de hidratación...
            FamilyFamilyRepository.Current.GetChildren(family);
            FamilyPatentRepository.Current.GetChildren(family);

            return family;
        }
    }
}
