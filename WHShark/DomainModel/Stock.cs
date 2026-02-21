using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Stock
    {
        public Guid StockId { get; set; }
        // keep ids for persistence but also include navigation properties
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }

        public Product Product { get; set; }
        public Branch Branch { get; set; }

        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
