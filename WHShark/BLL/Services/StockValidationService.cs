using BLL.Services.Interfaces;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class StockValidationService : IStockValidationService
    {
        private readonly IStockRepository _stockRepository;

        public StockValidationService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public bool HasSufficientStock(Guid productId, Guid branchId, int requestedQuantity)
        {
            int availableStock = _stockRepository.GetAvailableStock(productId, branchId);
            return requestedQuantity <= availableStock;
        }

    }

}
