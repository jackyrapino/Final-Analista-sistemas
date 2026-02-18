using BLL.Services.Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategies
{
    public class BirthdayDiscountStrategy : IPricingStrategy
    {
        private readonly ICustomerService _customerService;

        public BirthdayDiscountStrategy(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public decimal Apply(decimal baseAmount, Sale sale, IEnumerable<SaleItem> items)
        {
            if (!sale.CustomerId.HasValue)
                return baseAmount;

            var customerBirthday = _customerService.GetBirthday(sale.CustomerId.Value);
            if (customerBirthday.HasValue && customerBirthday.Value.Date == sale.SaleDate.Date)
                return baseAmount * 0.85m;

            return baseAmount;
        }

    }

}
