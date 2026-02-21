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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;

        public SupplierService(ISupplierRepository repo)
        {
            _repo = repo;
        }

        public SupplierService() : this(SupplierRepository.Current) { }

        public void Add(Supplier supplier)
        {
            try
            {
                if (supplier == null) throw new ArgumentNullException(nameof(supplier));
                if (supplier.SupplierId == Guid.Empty) supplier.SupplierId = Guid.NewGuid();
                supplier.CreatedAt = DateTime.Now;
                _repo.Add(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding supplier.", ex);
            }
        }

        public void Update(Supplier supplier)
        {
            try
            {
                if (supplier == null) throw new ArgumentNullException(nameof(supplier));
                _repo.Update(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier.", ex);
            }
        }

        public void Delete(Guid supplierId)
        {
            try
            {
                _repo.Delete(supplierId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier.", ex);
            }
        }

        public IEnumerable<Supplier> SelectAll()
        {
            try
            {
                return _repo.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers.", ex);
            }
        }

        public Supplier SelectOne(Guid supplierId)
        {
            try
            {
                return _repo.SelectOne(supplierId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving supplier.", ex);
            }
        }
    }
}
