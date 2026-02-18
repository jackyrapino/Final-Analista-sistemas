using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Builders.Interface
{
    public interface IStockMovementBuilder
    {
        IStockMovementBuilder SetBranches(Guid fromBranchId, Guid toBranchId);
        IStockMovementBuilder SetUser(Guid userId);
        IStockMovementBuilder AddItem(Guid productId, int quantity);
        StockMovement Build();
    }

}
