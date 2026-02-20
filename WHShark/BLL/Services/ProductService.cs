using System;
using System.Collections.Generic;
using BLL.Services.Contracts;
using DAL.Contracts;
using DAL.Implementations;
using DomainModel;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public ProductService() : this(ProductRepository.Current) { }

        public void Add(Product product)
        {
            try
            {
                if (product == null) throw new ArgumentNullException(nameof(product));
                if (product.ProductId == Guid.Empty) product.ProductId = Guid.NewGuid();
                product.CreatedAt = DateTime.Now;
                _repo.Add(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product.", ex);
            }
        }

        public void Update(Product product)
        {
            try
            {
                if (product == null) throw new ArgumentNullException(nameof(product));
                product.UpdatedAt = DateTime.Now;
                _repo.Update(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product.", ex);
            }
        }

        public void Delete(Guid productId)
        {
            try
            {
                _repo.Delete(productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product.", ex);
            }
        }

        public IEnumerable<Product> SelectAll()
        {
            try
            {
                return _repo.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products.", ex);
            }
        }

        public Product SelectOne(Guid productId)
        {
            try
            {
                return _repo.SelectOne(productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product.", ex);
            }
        }

        public IEnumerable<Product> GetByCategory(Guid categoryId)
        {
            try
            {
                return _repo.GetByCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by category.", ex);
            }
        }

        public IEnumerable<Product> Search(string term)
        {
            try
            {
                return _repo.Search(term);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching products.", ex);
            }
        }
    }
}
