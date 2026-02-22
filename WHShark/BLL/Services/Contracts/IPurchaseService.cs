using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface IPurchaseService
    {
        void Add(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(Guid purchaseId);
        IEnumerable<Purchase> SelectAll();
        Purchase SelectOne(Guid purchaseId);
    }
}
