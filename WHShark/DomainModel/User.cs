using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User
    {
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
    }
}
