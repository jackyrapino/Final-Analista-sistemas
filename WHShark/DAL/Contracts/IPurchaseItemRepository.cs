using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface IPurchaseItemRepository : IGenericRepository<PurchaseItem>
    {
        IEnumerable<PurchaseItem> GetByPurchase(Guid purchaseId);
    }
}
