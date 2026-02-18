using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        #region Singleton
        private readonly static CategoryRepository _instance = new CategoryRepository();
        public static CategoryRepository Current => _instance;
        private CategoryRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Category obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Category_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@CategoryId", obj.CategoryId),
                        new SqlParameter("@Name", obj.Name)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting category data.", ex);
            }
        }

        public void Update(Category obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Category_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@CategoryId", obj.CategoryId),
                        new SqlParameter("@Name", obj.Name)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating category data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Category_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@CategoryId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting category data.", ex);
            }
        }

        public IEnumerable<Category> SelectAll()
        {
            var list = new List<Category>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Category_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var c = new Category
                        {
                            CategoryId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            CreatedAt = DateTime.Parse(values[2].ToString())
                        };
                        list.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all categories.", ex);
            }
            return list;
        }

        public Category SelectOne(Guid id)
        {
            Category category = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Category_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@CategoryId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        category = new Category
                        {
                            CategoryId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            CreatedAt = DateTime.Parse(values[2].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a category by id.", ex);
            }
            return category;
        }
    }
}
