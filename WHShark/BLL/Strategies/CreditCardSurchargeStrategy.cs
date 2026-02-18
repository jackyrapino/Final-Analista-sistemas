using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategies
{
    public class CreditCardSurchargeStrategy : IPricingStrategy
    {
        public decimal Apply(decimal baseAmount, Sale sale, IEnumerable<SaleItem> items)
        {
            if (sale.PaymentMethod?.ToLower() == "tarjeta")
                return baseAmount * 1.10m;
            return baseAmount;
        }
    }

}
