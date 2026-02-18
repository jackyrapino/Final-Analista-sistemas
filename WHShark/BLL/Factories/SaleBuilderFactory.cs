using BLL.Builders;
using BLL.Builders.Interface;
using BLL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class SaleBuilderFactory
    {
        private readonly IPricingService _pricingService;

        public SaleBuilderFactory(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public ISaleBuilder Create()
        {
            return new SaleBuilder(_pricingService);
        }
    }

}
