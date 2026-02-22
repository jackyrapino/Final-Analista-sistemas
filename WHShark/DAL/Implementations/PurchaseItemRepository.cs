using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class PurchaseItemRepository : IPurchaseItemRepository
    {
        #region Singleton
        private readonly static PurchaseItemRepository _instance = new PurchaseItemRepository();
        public static PurchaseItemRepository Current => _instance;
        private PurchaseItemRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(PurchaseItem obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "PurchaseItem_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@PurchaseItemId", obj.PurchaseItemId),
                        new SqlParameter("@PurchaseId", obj.PurchaseId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@Quantity", obj.Quantity),
                        new SqlParameter("@UnitCost", obj.UnitCost)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting purchase item data.", ex);
            }
        }

        public void Update(PurchaseItem obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "PurchaseItem_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@PurchaseItemId", obj.PurchaseItemId),
                        new SqlParameter("@PurchaseId", obj.PurchaseId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@Quantity", obj.Quantity),
                        new SqlParameter("@UnitCost", obj.UnitCost)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating purchase item data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "PurchaseItem_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@PurchaseItemId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting purchase item data.", ex);
            }
        }

        public IEnumerable<PurchaseItem> SelectAll()
        {
            var list = new List<PurchaseItem>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "PurchaseItem_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var pi = new PurchaseItem
                        {
                            PurchaseItemId = Guid.Parse(values[0].ToString()),
                            PurchaseId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            UnitCost = decimal.Parse(values[4].ToString()),
                            TotalCost = string.IsNullOrEmpty(values[5]?.ToString()) ? (decimal?)null : decimal.Parse(values[5].ToString())
                        };
                        list.Add(pi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all purchase items.", ex);
            }
            return list;
        }

        public PurchaseItem SelectOne(Guid id)
        {
            PurchaseItem pi = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "PurchaseItem_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@PurchaseItemId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        pi = new PurchaseItem
                        {
                            PurchaseItemId = Guid.Parse(values[0].ToString()),
                            PurchaseId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            UnitCost = decimal.Parse(values[4].ToString()),
                            TotalCost = string.IsNullOrEmpty(values[5]?.ToString()) ? (decimal?)null : decimal.Parse(values[5].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a purchase item by id.", ex);
            }
            return pi;
        }

        public IEnumerable<PurchaseItem> GetByPurchase(Guid purchaseId)
        {
            var list = new List<PurchaseItem>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "PurchaseItem_GetByPurchase", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@PurchaseId", purchaseId) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var pi = new PurchaseItem
                        {
                            PurchaseItemId = Guid.Parse(values[0].ToString()),
                            PurchaseId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            UnitCost = decimal.Parse(values[4].ToString()),
                            TotalCost = string.IsNullOrEmpty(values[5]?.ToString()) ? (decimal?)null : decimal.Parse(values[5].ToString())
                        };
                        list.Add(pi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting purchase items by purchase id.", ex);
            }
            return list;
        }
    }
}
