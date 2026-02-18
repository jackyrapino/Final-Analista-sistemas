using System;
using System.Collections.Generic;
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
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Purchase_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@PurchaseId", obj.PurchaseId),
                        new SqlParameter("@SupplierId", obj.SupplierId),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@PurchaseDate", obj.PurchaseDate),
                        new SqlParameter("@TotalAmount", obj.TotalAmount),
                        new SqlParameter("@Status", obj.Status)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting purchase data.", ex);
            }
        }

        public void Update(Purchase obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Purchase_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@PurchaseId", obj.PurchaseId),
                        new SqlParameter("@SupplierId", obj.SupplierId),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@PurchaseDate", obj.PurchaseDate),
                        new SqlParameter("@TotalAmount", obj.TotalAmount),
                        new SqlParameter("@Status", obj.Status)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating purchase data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Purchase_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@PurchaseId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting purchase data.", ex);
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
                            SupplierId = Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            UserId = Guid.Parse(values[3].ToString()),
                            PurchaseDate = DateTime.Parse(values[4].ToString()),
                            TotalAmount = decimal.Parse(values[5].ToString()),
                            Status = values[6].ToString()
                        };
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
                            SupplierId = Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            UserId = Guid.Parse(values[3].ToString()),
                            PurchaseDate = DateTime.Parse(values[4].ToString()),
                            TotalAmount = decimal.Parse(values[5].ToString()),
                            Status = values[6].ToString()
                        };
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
