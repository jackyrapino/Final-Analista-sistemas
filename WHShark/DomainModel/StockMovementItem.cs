using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class StockMovementItem
    {
        public Guid MovementItemId { get; set; }
        public Guid MovementId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
