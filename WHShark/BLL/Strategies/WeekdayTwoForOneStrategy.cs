using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategies
{
    public class WeekdayTwoForOneStrategy : IPricingStrategy
    {
        public decimal Apply(decimal baseAmount, Sale sale, IEnumerable<SaleItem> items)
        {
            if (sale.SaleDate.DayOfWeek == DayOfWeek.Monday || sale.SaleDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                foreach (var group in items.GroupBy(i => i.ProductId))
                {
                    if (group.Sum(i => i.Quantity) >= 2)
                        return baseAmount * 0.75m;
                }
            }
            return baseAmount;
        }
    }

}
