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
            try
            {
                if (stock == null) throw new ArgumentNullException(nameof(stock));
                if (stock.StockId == Guid.Empty) stock.StockId = Guid.NewGuid();
                stock.LastUpdated = DateTime.Now;
                _repo.Add(stock);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding stock.", ex);
            }
        }

        public void Update(Stock stock)
        {
            try
            {
                if (stock == null) throw new ArgumentNullException(nameof(stock));
                stock.LastUpdated = DateTime.Now;
                _repo.Update(stock);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating stock.", ex);
            }
        }

        public void Delete(Guid stockId)
        {
            try
            {
                _repo.Delete(stockId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting stock.", ex);
            }
        }

        public IEnumerable<Stock> SelectAll()
        {
            try
            {
                return _repo.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stocks.", ex);
            }
        }

        public Stock SelectOne(Guid stockId)
        {
            try
            {
                return _repo.SelectOne(stockId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stock.", ex);
            }
        }

        public int GetAvailableStock(Guid productId, Guid branchId)
        {
            try
            {
                return _repo.GetAvailableStock(productId, branchId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving available stock.", ex);
            }
        }

        public IEnumerable<Stock> StockByBranch(Guid branchId)
        {
            try
            {
                return _repo.StockByBranch(branchId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stock by branch.", ex);
            }
        }
    }
}
