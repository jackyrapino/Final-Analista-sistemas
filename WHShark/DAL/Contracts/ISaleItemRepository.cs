using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface ISaleItemRepository : IGenericRepository<SaleItem>
    {
        IEnumerable<SaleItem> GetBySale(Guid saleId);
    }
}
