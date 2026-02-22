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
        public Supplier Supplier { get; set; }
        public Branch Branch { get; set; }
        public User User { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<PurchaseItem> Items { get; set; }
    }
}
