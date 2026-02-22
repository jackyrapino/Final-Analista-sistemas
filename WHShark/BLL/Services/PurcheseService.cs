using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using BLL.Services.Contracts;
using DAL.Contracts;
using DAL.Implementations;
using DomainModel;
using Services.BLL;

namespace BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repo;

        public PurchaseService(IPurchaseRepository repo)
        {
            _repo = repo;
        }

        public PurchaseService() : this(PurchaseRepository.Current) { }

        private List<PurchaseItem> ConsolidateItems(IEnumerable<PurchaseItem> items)
        {
            if (items == null) return new List<PurchaseItem>();

            var groups = items.GroupBy(i => i.ProductId);
            var result = new List<PurchaseItem>();
            foreach (var g in groups)
            {
                var list = g.ToList();
                var totalQty = list.Sum(x => x.Quantity);
                var last = list.Last();
                var unitCost = last.UnitCost;
                var existingId = list.Select(x => x.PurchaseItemId).FirstOrDefault(id => id != Guid.Empty);
                var pid = existingId == Guid.Empty ? Guid.NewGuid() : existingId;

                result.Add(new PurchaseItem
                {
                    PurchaseItemId = pid,
                    ProductId = g.Key,
                    Quantity = totalQty,
                    UnitCost = unitCost,
                    TotalCost = unitCost * totalQty
                });
            }
            return result;
        }

        private IEnumerable<Guid> FindDuplicateProductIds(IEnumerable<PurchaseItem> items)
        {
            if (items == null) return Enumerable.Empty<Guid>();
            return items.GroupBy(i => i.ProductId).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
        }

        public void Add(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException(nameof(purchase));
            if (purchase.PurchaseId == Guid.Empty) purchase.PurchaseId = Guid.NewGuid();

            purchase.Items = purchase.Items ?? new List<PurchaseItem>();

            var dupIds = FindDuplicateProductIds(purchase.Items).ToList();
            if (dupIds.Any())
            {
                var names = dupIds.Select(id => DAL.Implementations.ProductRepository.Current.SelectOne(id)?.Name ?? id.ToString()).ToList();
                throw new DuplicatePurchaseItemException("Duplicate products found in purchase items: " + string.Join(", ", names));
            }

            foreach (var item in purchase.Items)
            {
                if (item.PurchaseItemId == Guid.Empty) item.PurchaseItemId = Guid.NewGuid();
                item.PurchaseId = purchase.PurchaseId;
                if (!item.TotalCost.HasValue)
                    item.TotalCost = item.UnitCost * item.Quantity;
            }

            purchase.TotalAmount = purchase.Items.Sum(i => i.TotalCost ?? (i.UnitCost * i.Quantity));

            if (purchase.PurchaseDate == default(DateTime)) purchase.PurchaseDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(purchase.Status)) purchase.Status = DomainModel.PurchaseStatus.Pending;

            _repo.AddWithItems(purchase);

            if ((purchase.Status ?? string.Empty) == DomainModel.PurchaseStatus.Received)
            {
                ProcessReceivedStock(purchase);
            }
        }

        public void Update(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException(nameof(purchase));

            purchase.Items = purchase.Items ?? new List<PurchaseItem>();

            var dupIds = FindDuplicateProductIds(purchase.Items).ToList();
            if (dupIds.Any())
            {
                var names = dupIds.Select(id => DAL.Implementations.ProductRepository.Current.SelectOne(id)?.Name ?? id.ToString()).ToList();
                throw new DuplicatePurchaseItemException("Duplicate products found in purchase items: " + string.Join(", ", names));
            }

            foreach (var item in purchase.Items)
            {
                if (item.PurchaseItemId == Guid.Empty) item.PurchaseItemId = Guid.NewGuid();
                item.PurchaseId = purchase.PurchaseId;
                if (!item.TotalCost.HasValue)
                    item.TotalCost = item.UnitCost * item.Quantity;
            }

            purchase.TotalAmount = purchase.Items.Sum(i => i.TotalCost ?? (i.UnitCost * i.Quantity));

            if (purchase.PurchaseDate == default(DateTime)) purchase.PurchaseDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(purchase.Status)) purchase.Status = DomainModel.PurchaseStatus.Pending;

            string prevStatus = null;
            try
            {
                var existing = SelectOne(purchase.PurchaseId);
                prevStatus = existing?.Status;
            }
            catch
            {
                prevStatus = null;
            }

            _repo.UpdateWithItems(purchase);

            var nowStatus = purchase.Status ?? string.Empty;
            if ((prevStatus ?? string.Empty) != DomainModel.PurchaseStatus.Received && nowStatus == DomainModel.PurchaseStatus.Received)
            {
                ProcessReceivedStock(purchase);
            }
        }

        private void ProcessReceivedStock(Purchase purchase)
        {
            try
            {
                if (purchase == null) return;
                var branchId = purchase.Branch?.BranchId ?? Guid.Empty;
                if (branchId == Guid.Empty) return; 

                var stockSvc = new StockService();

                foreach (var item in purchase.Items ?? new List<PurchaseItem>())
                {
                    try
                    {
                        var stocks = stockSvc.StockByBranch(branchId)?.ToList() ?? new List<DomainModel.Stock>();
                        var existing = stocks.FirstOrDefault(s => s.Product != null && s.Product.ProductId == item.ProductId);

                        if (existing != null)
                        {
                            existing.Quantity += item.Quantity;
                            existing.LastUpdated = DateTime.Now;
                            stockSvc.Update(existing);
                        }
                        else
                        {
                            var prod = DAL.Implementations.ProductRepository.Current.SelectOne(item.ProductId);
                            var branch = DAL.Implementations.BranchRepository.Current.SelectOne(branchId);
                            var newStock = new DomainModel.Stock
                            {
                                StockId = Guid.Empty,
                                Product = prod,
                                Branch = branch,
                                Quantity = item.Quantity,
                                LastUpdated = DateTime.Now
                            };
                            stockSvc.Add(newStock);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Failed to update stock for purchase item: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed processing received stock: " + ex.ToString());
            }
        }

        public void AddConsolidated(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException(nameof(purchase));
            if (purchase.PurchaseId == Guid.Empty) purchase.PurchaseId = Guid.NewGuid();

            purchase.Items = ConsolidateItems(purchase.Items);
            foreach (var item in purchase.Items)
            {
                if (item.PurchaseItemId == Guid.Empty) item.PurchaseItemId = Guid.NewGuid();
                item.PurchaseId = purchase.PurchaseId;
                if (!item.TotalCost.HasValue)
                    item.TotalCost = item.UnitCost * item.Quantity;
            }
            purchase.TotalAmount = purchase.Items.Sum(i => i.TotalCost ?? (i.UnitCost * i.Quantity));
            if (purchase.PurchaseDate == default(DateTime)) purchase.PurchaseDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(purchase.Status)) purchase.Status = DomainModel.PurchaseStatus.Pending;
            _repo.AddWithItems(purchase);

            if ((purchase.Status ?? string.Empty) == DomainModel.PurchaseStatus.Received)
            {
                ProcessReceivedStock(purchase);
            }
        }

        public void UpdateConsolidated(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException(nameof(purchase));

            purchase.Items = ConsolidateItems(purchase.Items);
            foreach (var item in purchase.Items)
            {
                if (item.PurchaseItemId == Guid.Empty) item.PurchaseItemId = Guid.NewGuid();
                item.PurchaseId = purchase.PurchaseId;
                if (!item.TotalCost.HasValue)
                    item.TotalCost = item.UnitCost * item.Quantity;
            }
            purchase.TotalAmount = purchase.Items.Sum(i => i.TotalCost ?? (i.UnitCost * i.Quantity));
            if (purchase.PurchaseDate == default(DateTime)) purchase.PurchaseDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(purchase.Status)) purchase.Status = DomainModel.PurchaseStatus.Pending;
            _repo.UpdateWithItems(purchase);

            var prevStatus = SelectOne(purchase.PurchaseId)?.Status;
            if ((prevStatus ?? string.Empty) != DomainModel.PurchaseStatus.Received && (purchase.Status ?? string.Empty) == DomainModel.PurchaseStatus.Received)
            {
                ProcessReceivedStock(purchase);
            }
        }

        public void Delete(Guid purchaseId)
        {
            _repo.DeleteWithItems(purchaseId);
        }

        public IEnumerable<Purchase> SelectAll()
        {
            var list = _repo.SelectAll()?.ToList() ?? new List<Purchase>();
            foreach (var p in list)
            {
                p.Items = PurchaseItemRepository.Current.GetByPurchase(p.PurchaseId).ToList();
            }
            return list;
        }

        public Purchase SelectOne(Guid purchaseId)
        {
            var p = _repo.SelectOne(purchaseId);
            if (p == null) return null;
            p.Items = PurchaseItemRepository.Current.GetByPurchase(p.PurchaseId).ToList();
            return p;
        }
    }
}
