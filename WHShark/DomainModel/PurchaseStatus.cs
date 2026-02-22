using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public static class PurchaseStatus
    {
        public const string Pending = "Pending";
        public const string Received = "Received";
        public const string Cancelled = "Cancelled";

        public static IEnumerable<string> List()
        {
            return new[] { Pending, Received, Cancelled };
        }
    }
}
