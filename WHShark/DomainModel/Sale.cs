using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

    }
}
