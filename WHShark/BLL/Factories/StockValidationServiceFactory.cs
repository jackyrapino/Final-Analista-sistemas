using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Contracts;
using DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public static class StockValidationServiceFactory
    {
        public static IStockValidationService Create()
        {
            IStockRepository stockRepo = StockRepository.Current;
            return new StockValidationService(stockRepo);
        }
    }

}
