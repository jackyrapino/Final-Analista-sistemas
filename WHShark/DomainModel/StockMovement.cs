using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class StockMovement
    {
        public Guid MovementId { get; set; }
        public Guid FromBranchId { get; set; }
        public Guid ToBranchId { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime MovementDate { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
    }
}
