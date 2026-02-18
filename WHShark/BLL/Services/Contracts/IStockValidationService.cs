using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IStockValidationService
    {
        bool HasSufficientStock(Guid productId, Guid branchId, int requestedQuantity);
    }

}
