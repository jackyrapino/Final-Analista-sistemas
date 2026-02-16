using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Purchase
    {
        public Guid PurchaseId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
