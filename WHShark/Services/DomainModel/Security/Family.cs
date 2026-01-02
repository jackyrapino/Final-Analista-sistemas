using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.Security
{
    internal class Family
    {
        public string Name { get; set; }

        public List<Patent> Patents { get; set; }

        public List<Family> Families { get; set; }


    }
}
