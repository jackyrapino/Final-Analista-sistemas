using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface IStockMovementItemRepository : IGenericRepository<StockMovementItem>
    {
        IEnumerable<StockMovementItem> GetByMovement(Guid movementId);
    }
}
