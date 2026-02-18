using BLL.Services;
using BLL.Services.Contracts;
using BLL.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public static class PricingServiceFactory
    {
        public static IPricingService Create(ICustomerService customerService)
        {
            var strategies = new List<IPricingStrategy>
            {
                new BirthdayDiscountStrategy(customerService),
                new CashPaymentDiscountStrategy(),
                new CreditCardSurchargeStrategy(),
                new WeekdayTwoForOneStrategy()
            };

            return new PricingService(strategies);
        }
    }

}
