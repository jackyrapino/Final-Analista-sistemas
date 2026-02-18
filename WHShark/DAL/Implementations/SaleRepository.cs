using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class SaleRepository : ISaleRepository
    {
        #region Singleton
        private readonly static SaleRepository _instance = new SaleRepository();
        public static SaleRepository Current => _instance;
        private SaleRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Sale obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Sale_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@SaleId", obj.SaleId),
                        new SqlParameter("@CustomerId", (object)obj.CustomerId ?? DBNull.Value),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@SaleDate", obj.SaleDate),
                        new SqlParameter("@TotalAmount", obj.TotalAmount),
                        new SqlParameter("@PaymentMethod", (object)obj.PaymentMethod ?? DBNull.Value),
                        new SqlParameter("@Status", obj.Status)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting sale data.", ex);
            }
        }

        public void Update(Sale obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Sale_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@SaleId", obj.SaleId),
                        new SqlParameter("@CustomerId", (object)obj.CustomerId ?? DBNull.Value),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@SaleDate", obj.SaleDate),
                        new SqlParameter("@TotalAmount", obj.TotalAmount),
                        new SqlParameter("@PaymentMethod", (object)obj.PaymentMethod ?? DBNull.Value),
                        new SqlParameter("@Status", obj.Status)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating sale data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Sale_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SaleId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting sale data.", ex);
            }
        }

        public IEnumerable<Sale> SelectAll()
        {
            var list = new List<Sale>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Sale_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var s = new Sale
                        {
                            SaleId = Guid.Parse(values[0].ToString()),
                            CustomerId = string.IsNullOrEmpty(values[1]?.ToString()) ? (Guid?)null : Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            UserId = Guid.Parse(values[3].ToString()),
                            SaleDate = DateTime.Parse(values[4].ToString()),
                            TotalAmount = decimal.Parse(values[5].ToString()),
                            PaymentMethod = values[6]?.ToString(),
                            Status = values[7]?.ToString()
                        };
                        list.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all sales.", ex);
            }
            return list;
        }

        public Sale SelectOne(Guid id)
        {
            Sale sale = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Sale_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SaleId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        sale = new Sale
                        {
                            SaleId = Guid.Parse(values[0].ToString()),
                            CustomerId = string.IsNullOrEmpty(values[1]?.ToString()) ? (Guid?)null : Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            UserId = Guid.Parse(values[3].ToString()),
                            SaleDate = DateTime.Parse(values[4].ToString()),
                            TotalAmount = decimal.Parse(values[5].ToString()),
                            PaymentMethod = values[6]?.ToString(),
                            Status = values[7]?.ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a sale by id.", ex);
            }
            return sale;
        }
    }
}
