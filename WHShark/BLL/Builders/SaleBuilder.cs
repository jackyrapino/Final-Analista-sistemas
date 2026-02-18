using BLL.Builders.Interface;
using BLL.Services;
using BLL.Services.Contracts;
using BLL.Strategies;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Builders
{
    public class SaleBuilder : ISaleBuilder
    {
        private Sale _sale;
        private List<SaleItem> _items;
        private readonly IPricingService _pricingService;

        public SaleBuilder(IPricingService pricingService)
        {
            _sale = new Sale
            {
                SaleId = Guid.NewGuid(),
                SaleDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = 0
            };
            _items = new List<SaleItem>();
            _pricingService = pricingService;
        }

        public ISaleBuilder SetCustomer(Guid? customerId)
        {
            _sale.CustomerId = customerId;
            return this;
        }

        public ISaleBuilder SetBranch(Guid branchId)
        {
            _sale.BranchId = branchId;
            return this;
        }

        public ISaleBuilder SetUser(Guid userId)
        {
            _sale.UserId = userId;
            return this;
        }

        public ISaleBuilder AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = new SaleItem
            {
                SaleItemId = Guid.NewGuid(),
                SaleId = _sale.SaleId,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice
            };
            _items.Add(item);
            _sale.TotalAmount += quantity * unitPrice;
            return this;
        }

        public Sale Build()
        {
            _sale.TotalAmount = _pricingService.CalculateFinalAmount(_sale, _items);
            return _sale;
        }
    }


}
