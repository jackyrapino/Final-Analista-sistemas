using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetByCategory(Guid categoryId);
        IEnumerable<Product> Search(string term);
    }
}
