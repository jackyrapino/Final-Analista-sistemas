using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using DAL.Contracts;
using DAL.Implementations;
using DomainModel;

namespace BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repo;

        public StockService(IStockRepository repo)
        {
            _repo = repo;
        }

        public StockService() : this(StockRepository.Current) { }

        public void Add(Stock stock)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock));
            if (stock.StockId == Guid.Empty) stock.StockId = Guid.NewGuid();
            stock.LastUpdated = DateTime.Now;
            _repo.Add(stock);
        }

        public void Update(Stock stock)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock));
            stock.LastUpdated = DateTime.Now;
            _repo.Update(stock);
        }

        public void Delete(Guid stockId)
        {
            _repo.Delete(stockId);
        }

        public IEnumerable<Stock> SelectAll()
        {
            return _repo.SelectAll();
        }

        public Stock SelectOne(Guid stockId)
        {
            return _repo.SelectOne(stockId);
        }

        public int GetAvailableStock(Guid productId, Guid branchId)
        {
            return _repo.GetAvailableStock(productId, branchId);
        }

        public IEnumerable<Stock> StockByBranch(Guid branchId)
        {
            return _repo.StockByBranch(branchId);
        }
    }
}
