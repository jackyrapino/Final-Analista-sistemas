using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BranchId { get; set; }
        public decimal? Volume { get; set; }
        public string VolumeUnit { get; set; }
        public decimal? Weight { get; set; }
        public string WeightUnit { get; set; }
        public decimal CostPrice { get; set; }
        public decimal ListPrice { get; set; }
        public int AlertStock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

      
    }
}
