using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategies
{
    public class CashPaymentDiscountStrategy : IPricingStrategy
    {
        public decimal Apply(decimal baseAmount, Sale sale, IEnumerable<SaleItem> items)
        {
            if (sale.PaymentMethod?.ToLower() == "efectivo")
                return baseAmount * 0.90m;
            return baseAmount;
        }
    }

}
