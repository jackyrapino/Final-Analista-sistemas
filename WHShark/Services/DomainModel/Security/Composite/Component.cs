using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.Security.Composite
{
    public abstract class Component
    {
        public Guid IdComponent { get; set; }

        /// 
        /// <param name="component"></param>
        public abstract void Add(Component component);

        /// 
        /// <param name="component"></param>
        public abstract void Remove(Component component);

        /// <summary>
        /// Retorna la cantidad de hijos del elemento:
        /// Patente: 0
        /// Familia: >0
        /// </summary>
        /// <returns></returns>
        public abstract int ChildrenCount();

    }
}
