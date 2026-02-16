using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Branch
    {
        public Guid BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsWeb { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
