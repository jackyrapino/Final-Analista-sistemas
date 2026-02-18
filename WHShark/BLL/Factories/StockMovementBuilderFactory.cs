using BLL.Builders;
using BLL.Builders.Interface;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class StockMovementBuilderFactory
    {
        private readonly IStockValidationService _stockValidationService;

        public StockMovementBuilderFactory(IStockValidationService stockValidationService)
        {
            _stockValidationService = stockValidationService;
        }

        public IStockMovementBuilder Create()
        {
            return new StockMovementBuilder(_stockValidationService);
        }
    }

}
