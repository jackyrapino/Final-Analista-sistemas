using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        void AddWithItems(Purchase purchase);
        void UpdateWithItems(Purchase purchase);
        void DeleteWithItems(Guid purchaseId);
    }
}
