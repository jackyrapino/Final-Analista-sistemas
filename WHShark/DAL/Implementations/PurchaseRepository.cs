using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class PurchaseRepository : IPurchaseRepository
    {
        #region Singleton
        private readonly static PurchaseRepository _instance = new PurchaseRepository();
        public static PurchaseRepository Current => _instance;
        private PurchaseRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Purchase obj)
        {
            AddWithItems(obj);
        }

        public void Update(Purchase obj)
        {
            UpdateWithItems(obj);
        }

        public void Delete(Guid id)
        {
            DeleteWithItems(id);
        }

        public void AddWithItems(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException(nameof(purchase));

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Purchase_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@PurchaseId", purchase.PurchaseId),
                        new SqlParameter("@SupplierId", purchase.Supplier?.SupplierId ?? Guid.Empty),
                        new SqlParameter("@BranchId", purchase.Branch?.BranchId ?? Guid.Empty),
                        new SqlParameter("@UserId", purchase.User?.UserId ?? Guid.Empty),
                        new SqlParameter("@PurchaseDate", purchase.PurchaseDate),
                        new SqlParameter("@TotalAmount", purchase.TotalAmount),
                        new SqlParameter("@Status", purchase.Status)
                    });

                foreach (var item in purchase.Items ?? new List<PurchaseItem>())
                {
                    PurchaseItemRepository.Current.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting purchase and items.", ex);
            }
        }

        public void UpdateWithItems(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException(nameof(purchase));

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Purchase_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@PurchaseId", purchase.PurchaseId),
                        new SqlParameter("@SupplierId", purchase.Supplier?.SupplierId ?? Guid.Empty),
                        new SqlParameter("@BranchId", purchase.Branch?.BranchId ?? Guid.Empty),
                        new SqlParameter("@UserId", purchase.User?.UserId ?? Guid.Empty),
                        new SqlParameter("@PurchaseDate", purchase.PurchaseDate),
                        new SqlParameter("@TotalAmount", purchase.TotalAmount),
                        new SqlParameter("@Status", purchase.Status)
                    });

                var existing = PurchaseItemRepository.Current.GetByPurchase(purchase.PurchaseId).ToList();

                foreach (var item in purchase.Items ?? new List<PurchaseItem>())
                {
                    var ex = existing.FirstOrDefault(x => x.PurchaseItemId == item.PurchaseItemId);
                    if (ex == null)
                        PurchaseItemRepository.Current.Add(item);
                    else
                        PurchaseItemRepository.Current.Update(item);
                }

                var toDelete = existing.Where(e => !purchase.Items.Any(i => i.PurchaseItemId == e.PurchaseItemId)).ToList();
                foreach (var d in toDelete)
                {
                    PurchaseItemRepository.Current.Delete(d.PurchaseItemId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating purchase and items.", ex);
            }
        }

        public void DeleteWithItems(Guid purchaseId)
        {
            try
            {
                var items = PurchaseItemRepository.Current.GetByPurchase(purchaseId);
                foreach (var it in items)
                    PurchaseItemRepository.Current.Delete(it.PurchaseItemId);

                SqlHelper.ExecuteNonQuery(ConnectionName, "Purchase_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@PurchaseId", purchaseId) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting purchase and its items.", ex);
            }
        }

        public IEnumerable<Purchase> SelectAll()
        {
            var list = new List<Purchase>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Purchase_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var p = new Purchase
                        {
                            PurchaseId = Guid.Parse(values[0].ToString()),
                            PurchaseDate = DateTime.Parse(values[4].ToString()),
                            TotalAmount = decimal.Parse(values[5].ToString()),
                            Status = values[6].ToString()
                        };
                        try { p.Supplier = SupplierRepository.Current.SelectOne(Guid.Parse(values[1].ToString())); } catch { p.Supplier = null; }
                        try { p.Branch = BranchRepository.Current.SelectOne(Guid.Parse(values[2].ToString())); } catch { p.Branch = null; }
                        try { p.User = DAL.Implementations.UserRepository.Current.SelectOne(Guid.Parse(values[3].ToString())); } catch { p.User = null; }
                        list.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all purchases.", ex);
            }
            return list;
        }

        public Purchase SelectOne(Guid id)
        {
            Purchase purchase = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Purchase_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@PurchaseId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        purchase = new Purchase
                        {
                            PurchaseId = Guid.Parse(values[0].ToString()),
                            PurchaseDate = DateTime.Parse(values[4].ToString()),
                            TotalAmount = decimal.Parse(values[5].ToString()),
                            Status = values[6].ToString()
                        };
                        try { purchase.Supplier = SupplierRepository.Current.SelectOne(Guid.Parse(values[1].ToString())); } catch { purchase.Supplier = null; }
                        try { purchase.Branch = BranchRepository.Current.SelectOne(Guid.Parse(values[2].ToString())); } catch { purchase.Branch = null; }
                        try { purchase.User = DAL.Implementations.UserRepository.Current.SelectOne(Guid.Parse(values[3].ToString())); } catch { purchase.User = null; }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a purchase by id.", ex);
            }
            return purchase;
        }

    }
}
