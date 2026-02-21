using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface ISupplierService
    {
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Guid supplierId);
        IEnumerable<Supplier> SelectAll();
        Supplier SelectOne(Guid supplierId);
    }
}
