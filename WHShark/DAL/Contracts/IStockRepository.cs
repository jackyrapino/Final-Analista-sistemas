using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        int GetAvailableStock(Guid productId, Guid branchId);

    }
}
