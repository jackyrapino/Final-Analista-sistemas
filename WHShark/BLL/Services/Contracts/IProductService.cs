using System;
using System.Collections.Generic;
using DomainModel;

namespace BLL.Services.Contracts
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid productId);
        IEnumerable<Product> SelectAll();
        Product SelectOne(Guid productId);
        IEnumerable<Product> GetByCategory(Guid categoryId);
        IEnumerable<Product> Search(string term);
    }
}
