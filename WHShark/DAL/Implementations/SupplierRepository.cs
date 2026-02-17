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
    public sealed class SupplierRepository : ISupplierRepository
    {
        #region Singleton
        private readonly static SupplierRepository _instance = new SupplierRepository();
        public static SupplierRepository Current => _instance;
        private SupplierRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Supplier obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Supplier_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@SupplierId", obj.SupplierId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Email", (object)obj.Email ?? DBNull.Value),
                        new SqlParameter("@Phone", (object)obj.Phone ?? DBNull.Value),
                        new SqlParameter("@Address", (object)obj.Address ?? DBNull.Value),
                        new SqlParameter("@CreatedAt", obj.CreatedAt)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public void Update(Supplier obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Supplier_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@SupplierId", obj.SupplierId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Email", (object)obj.Email ?? DBNull.Value),
                        new SqlParameter("@Phone", (object)obj.Phone ?? DBNull.Value),
                        new SqlParameter("@Address", (object)obj.Address ?? DBNull.Value),
                        new SqlParameter("@CreatedAt", obj.CreatedAt)
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
                SqlHelper.ExecuteNonQuery(ConnectionName, "Supplier_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SupplierId", id) });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public IEnumerable<Supplier> SelectAll()
        {
            var list = new List<Supplier>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Supplier_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var s = new Supplier
                        {
                            SupplierId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Email = values[2]?.ToString(),
                            Phone = values[3]?.ToString(),
                            Address = values[4]?.ToString(),
                            CreatedAt = DateTime.Parse(values[5].ToString())
                        };
                        list.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return list;
        }

        public Supplier SelectOne(Guid id)
        {
            Supplier supplier = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Supplier_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@SupplierId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        supplier = new Supplier
                        {
                            SupplierId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Email = values[2]?.ToString(),
                            Phone = values[3]?.ToString(),
                            Address = values[4]?.ToString(),
                            CreatedAt = DateTime.Parse(values[5].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return supplier;
        }
    }
}
