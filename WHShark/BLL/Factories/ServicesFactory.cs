using BLL.Builders;
using BLL.Builders.Interface;
using BLL.Services;
using BLL.Services.Contracts;
using BLL.Services.Interfaces;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public static class ServicesFactory
    {
        public static ISaleBuilder CreateSaleBuilder(ICustomerRepository customerRepo)
        {
            ICustomerService customerService = new CustomerService(customerRepo);

            IPricingService pricingService = PricingServiceFactory.Create(customerService);

            return new SaleBuilder(pricingService);
        }

        public static IStockMovementBuilder CreateStockMovementBuilder()
        {
            IStockValidationService stockValidationService = StockValidationServiceFactory.Create();

            return new StockMovementBuilder(stockValidationService);
        }
    }

}
