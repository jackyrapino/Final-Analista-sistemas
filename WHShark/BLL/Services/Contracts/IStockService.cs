using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface IStockService
    {
        void Add(Stock stock);
        void Update(Stock stock);
        void Delete(Guid stockId);
        IEnumerable<Stock> SelectAll();
        Stock SelectOne(Guid stockId);
        int GetAvailableStock(Guid productId, Guid branchId);
        IEnumerable<Stock> StockByBranch(Guid branchId);
    }
}
