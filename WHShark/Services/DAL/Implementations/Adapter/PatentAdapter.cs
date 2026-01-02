using Services.DAL.Contracts;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.Adapter
{
    public sealed class PatentAdapter : IAdapter<Patent>
    {
        #region Singleton
        private readonly static PatentAdapter _instance = new PatentAdapter();

        public static PatentAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private PatentAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public DomainModel.Security.Composite.Patent Adapt(object[] values)
        {
            //Hidratar el objeto patente
            Patent patent = new Patent()
            {
                IdComponent = Guid.Parse(values[0].ToString()),
                MenuItemName = values[1].ToString(),
                FormName = values[2].ToString()
            };
            return patent;
        }
    }
}
