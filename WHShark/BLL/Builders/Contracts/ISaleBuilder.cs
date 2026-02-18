using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Builders.Interface
{
    public interface ISaleBuilder
    {
        ISaleBuilder SetCustomer(Guid? customerId);
        ISaleBuilder SetBranch(Guid branchId);
        ISaleBuilder SetUser(Guid userId);
        ISaleBuilder AddItem(Guid productId, int quantity, decimal unitPrice);
        Sale Build();
    }

}
