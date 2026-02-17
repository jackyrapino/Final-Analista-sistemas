using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using Services.Services.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class SaleItemRepository : ISaleItemRepository
    {
        #region Singleton
        private readonly static SaleItemRepository _instance = new SaleItemRepository();
        public static SaleItemRepository Current => _instance;
        private SaleItemRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(SaleItem obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "SaleItem_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@SaleItemId", obj.SaleItemId),
                        new SqlParameter("@SaleId", obj.SaleId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@Quantity", obj.Quantity),
                        new SqlParameter("@UnitPrice", obj.UnitPrice),
                        new SqlParameter("@TotalPrice", (object)obj.TotalPrice ?? DBNull.Value)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public void Update(SaleItem obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "SaleItem_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@SaleItemId", obj.SaleItemId),
                        new SqlParameter("@SaleId", obj.SaleId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@Quantity", obj.Quantity),
                        new SqlParameter("@UnitPrice", obj.UnitPrice),
                        new SqlParameter("@TotalPrice", (object)obj.TotalPrice ?? DBNull.Value)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "SaleItem_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SaleItemId", id) });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public IEnumerable<SaleItem> SelectAll()
        {
            var list = new List<SaleItem>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "SaleItem_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var si = new SaleItem
                        {
                            SaleItemId = Guid.Parse(values[0].ToString()),
                            SaleId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            UnitPrice = decimal.Parse(values[4].ToString()),
                            TotalPrice = string.IsNullOrEmpty(values[5]?.ToString()) ? (decimal?)null : decimal.Parse(values[5].ToString())
                        };
                        list.Add(si);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return list;
        }

        public SaleItem SelectOne(Guid id)
        {
            SaleItem si = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "SaleItem_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SaleItemId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        si = new SaleItem
                        {
                            SaleItemId = Guid.Parse(values[0].ToString()),
                            SaleId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            UnitPrice = decimal.Parse(values[4].ToString()),
                            TotalPrice = string.IsNullOrEmpty(values[5]?.ToString()) ? (decimal?)null : decimal.Parse(values[5].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return si;
        }

        public IEnumerable<SaleItem> GetBySale(Guid saleId)
        {
            var list = new List<SaleItem>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "SaleItem_GetBySale", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SaleId", saleId) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var si = new SaleItem
                        {
                            SaleItemId = Guid.Parse(values[0].ToString()),
                            SaleId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            UnitPrice = decimal.Parse(values[4].ToString()),
                            TotalPrice = string.IsNullOrEmpty(values[5]?.ToString()) ? (decimal?)null : decimal.Parse(values[5].ToString())
                        };
                        list.Add(si);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return list;
        }
    }
}
