using BLL.Services.Contracts;
using BLL.Strategies;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PricingService : IPricingService
    {
        private readonly List<IPricingStrategy> _strategies;

        public PricingService(IEnumerable<IPricingStrategy> strategies)
        {
            _strategies = strategies.ToList();
        }

        public decimal CalculateFinalAmount(Sale sale, IEnumerable<SaleItem> items)
        {
            decimal amount = sale.TotalAmount;

            foreach (var strategy in _strategies)
            {
                amount = strategy.Apply(amount, sale, items);
            }

            return amount;
        }
    }

}
