using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategies
{
    public interface IPricingStrategy
    {
        decimal Apply(decimal baseAmount, Sale sale, IEnumerable<SaleItem> items);
    }

}
