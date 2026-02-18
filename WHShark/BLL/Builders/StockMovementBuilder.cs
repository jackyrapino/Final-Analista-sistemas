using BLL.Builders.Interface;
using BLL.Services.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Builders
{
    public class StockMovementBuilder : IStockMovementBuilder
    {
        private StockMovement _movement;
        private List<StockMovementItem> _items;
        private readonly IStockValidationService _stockValidationService;

        public StockMovementBuilder(IStockValidationService stockValidationService)
        {
            _movement = new StockMovement
            {
                MovementId = Guid.NewGuid(),
                MovementDate = DateTime.Now,
                Status = "Pending"
            };
            _items = new List<StockMovementItem>();
            _stockValidationService = stockValidationService;
        }

        public IStockMovementBuilder SetBranches(Guid fromBranchId, Guid toBranchId)
        {
            _movement.FromBranchId = fromBranchId;
            _movement.ToBranchId = toBranchId;
            return this;
        }

        public IStockMovementBuilder SetUser(Guid userId)
        {
            _movement.UserId = userId;
            return this;
        }

        public IStockMovementBuilder AddItem(Guid productId, int quantity)
        {
            if (!_stockValidationService.HasSufficientStock(productId, _movement.FromBranchId, quantity))
                throw new InvalidOperationException("No hay suficiente stock disponible para transferir.");

            var item = new StockMovementItem
            {
                MovementItemId = Guid.NewGuid(),
                MovementId = _movement.MovementId,
                ProductId = productId,
                Quantity = quantity
            };
            _items.Add(item);
            return this;
        }

        public StockMovement Build()
        {
            return _movement;
        }
    }


}
