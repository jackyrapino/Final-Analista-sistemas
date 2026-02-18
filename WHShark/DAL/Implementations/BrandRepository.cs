using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class BrandRepository : IBrandRepository
    {
        #region Singleton
        private readonly static BrandRepository _instance = new BrandRepository();
        public static BrandRepository Current => _instance;
        private BrandRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Brand obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Brand_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@BrandId", obj.BrandId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Description", obj.Description)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting brand data.", ex);
            }
        }

        public void Update(Brand obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Brand_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@BrandId", obj.BrandId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Description", obj.Description)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating brand data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Brand_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@BrandId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting brand data.", ex);
            }
        }

        public IEnumerable<Brand> SelectAll()
        {
            var list = new List<Brand>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Brand_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var b = new Brand
                        {
                            BrandId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Description = values[2].ToString(),
                            CreatedAt = DateTime.Parse(values[3].ToString())
                        };
                        list.Add(b);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all brands.", ex);
            }
            return list;
        }

        public Brand SelectOne(Guid id)
        {
            Brand brand = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Brand_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@BrandId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        brand = new Brand
                        {
                            BrandId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Description = values[2].ToString(),
                            CreatedAt = DateTime.Parse(values[3].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a brand by id.", ex);
            }
            return brand;
        }

        public Brand GetByName(string name)
        {
            Brand brand = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Brand_SelectByName", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@Name", name) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        brand = new Brand
                        {
                            BrandId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Description = values[2].ToString(),
                            CreatedAt = DateTime.Parse(values[3].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a brand by name.", ex);
            }
            return brand;
        }

        public IEnumerable<Brand> SearchByName(string term)
        {
            var list = new List<Brand>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Brand_SearchByName", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@Term", term) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var b = new Brand
                        {
                            BrandId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Description = values[2].ToString(),
                            CreatedAt = DateTime.Parse(values[3].ToString())
                        };
                        list.Add(b);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while searching brands by name.", ex);
            }
            return list;
        }
    }
}
