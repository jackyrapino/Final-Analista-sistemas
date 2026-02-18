using DAL.Contracts;
using DomainModel;
using DAL.Tools;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class ProductRepository : IProductRepository
    {
        #region Singleton
        private readonly static ProductRepository _instance = new ProductRepository();


        public static ProductRepository Current => _instance;

        private ProductRepository()
        {
           
        }
        #endregion
        
        private const string ConnectionName = "ManagerBusiness";

        public void Add(Product obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Product_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                    new SqlParameter("@ProductId", obj.ProductId),
                    new SqlParameter("@SKU", obj.SKU),
                    new SqlParameter("@Barcode", obj.Barcode),
                    new SqlParameter("@Name", obj.Name),
                    new SqlParameter("@Description", obj.Description),
                    new SqlParameter("@BrandId", obj.BrandId),
                    new SqlParameter("@CategoryId", obj.CategoryId),
                    new SqlParameter("@BranchId", obj.BranchId),
                    new SqlParameter("@Volume", (object)obj.Volume ?? DBNull.Value),
                    new SqlParameter("@VolumeUnit", (object)obj.VolumeUnit ?? DBNull.Value),
                    new SqlParameter("@Weight", (object)obj.Weight ?? DBNull.Value),
                    new SqlParameter("@WeightUnit", (object)obj.WeightUnit ?? DBNull.Value),
                    new SqlParameter("@CostPrice", obj.CostPrice),
                    new SqlParameter("@ListPrice", obj.ListPrice),
                    new SqlParameter("@AlertStock", obj.AlertStock)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting product data.", ex);
            }

        }

        public void Update(Product obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Product_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                    new SqlParameter("@ProductId", obj.ProductId),
                    new SqlParameter("@SKU", obj.SKU),
                    new SqlParameter("@Barcode", obj.Barcode),
                    new SqlParameter("@Name", obj.Name),
                    new SqlParameter("@Description", obj.Description),
                    new SqlParameter("@BrandId", obj.BrandId),
                    new SqlParameter("@CategoryId", obj.CategoryId),
                    new SqlParameter("@BranchId", obj.BranchId),
                    new SqlParameter("@Volume", (object)obj.Volume ?? DBNull.Value),
                    new SqlParameter("@VolumeUnit", (object)obj.VolumeUnit ?? DBNull.Value),
                    new SqlParameter("@Weight", (object)obj.Weight ?? DBNull.Value),
                    new SqlParameter("@WeightUnit", (object)obj.WeightUnit ?? DBNull.Value),
                    new SqlParameter("@CostPrice", obj.CostPrice),
                    new SqlParameter("@ListPrice", obj.ListPrice),
                    new SqlParameter("@AlertStock", obj.AlertStock)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating product data.", ex);
            }

        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Product_Delete", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                    new SqlParameter("@ProductId", id)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting product data.", ex);
            }

        }

        public IEnumerable<Product> SelectAll()
        {
            var list = new List<Product>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Product_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var p = new Product
                        {
                            ProductId = Guid.Parse(values[0].ToString()),
                            SKU = values[1].ToString(),
                            Barcode = values[2].ToString(),
                            Name = values[3].ToString(),
                            Description = values[4].ToString(),
                            BrandId = Guid.Parse(values[5].ToString()),
                            CategoryId = Guid.Parse(values[6].ToString()),
                            BranchId = Guid.Parse(values[7].ToString()),
                            Volume = string.IsNullOrEmpty(values[8]?.ToString()) ? (decimal?)null : decimal.Parse(values[8].ToString()),
                            VolumeUnit = values[9]?.ToString(),
                            Weight = string.IsNullOrEmpty(values[10]?.ToString()) ? (decimal?)null : decimal.Parse(values[10].ToString()),
                            WeightUnit = values[11]?.ToString(),
                            CostPrice = decimal.Parse(values[12].ToString()),
                            ListPrice = decimal.Parse(values[13].ToString()),
                            AlertStock = int.Parse(values[14].ToString()),
                            CreatedAt = DateTime.Parse(values[15].ToString()),
                            UpdatedAt = string.IsNullOrEmpty(values[16]?.ToString()) ? (DateTime?)null : DateTime.Parse(values[16].ToString())
                        };
                        list.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all products.", ex);
            }
            return list;

        }

        public Product SelectOne(Guid id)
        {
            Product product = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Product_SelectOne", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@ProductId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        product = new Product
                        {
                            ProductId = Guid.Parse(values[0].ToString()),
                            SKU = values[1].ToString(),
                            Barcode = values[2].ToString(),
                            Name = values[3].ToString(),
                            Description = values[4].ToString(),
                            BrandId = Guid.Parse(values[5].ToString()),
                            CategoryId = Guid.Parse(values[6].ToString()),
                            BranchId = Guid.Parse(values[7].ToString()),
                            Volume = string.IsNullOrEmpty(values[8]?.ToString()) ? (decimal?)null : decimal.Parse(values[8].ToString()),
                            VolumeUnit = values[9]?.ToString(),
                            Weight = string.IsNullOrEmpty(values[10]?.ToString()) ? (decimal?)null : decimal.Parse(values[10].ToString()),
                            WeightUnit = values[11]?.ToString(),
                            CostPrice = decimal.Parse(values[12].ToString()),
                            ListPrice = decimal.Parse(values[13].ToString()),
                            AlertStock = int.Parse(values[14].ToString()),
                            CreatedAt = DateTime.Parse(values[15].ToString()),
                            UpdatedAt = string.IsNullOrEmpty(values[16]?.ToString()) ? (DateTime?)null : DateTime.Parse(values[16].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a product by id.", ex);
            }
            return product;

        }

        public IEnumerable<Product> GetByCategory(Guid categoryId)
        {
            var list = new List<Product>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Product_GetByCategory", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@CategoryId", categoryId) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var p = new Product
                        {
                            ProductId = Guid.Parse(values[0].ToString()),
                            SKU = values[1].ToString(),
                            Barcode = values[2].ToString(),
                            Name = values[3].ToString(),
                            Description = values[4].ToString(),
                            BrandId = Guid.Parse(values[5].ToString()),
                            CategoryId = Guid.Parse(values[6].ToString()),
                            BranchId = Guid.Parse(values[7].ToString()),
                            Volume = string.IsNullOrEmpty(values[8]?.ToString()) ? (decimal?)null : decimal.Parse(values[8].ToString()),
                            VolumeUnit = values[9]?.ToString(),
                            Weight = string.IsNullOrEmpty(values[10]?.ToString()) ? (decimal?)null : decimal.Parse(values[10].ToString()),
                            WeightUnit = values[11]?.ToString(),
                            CostPrice = decimal.Parse(values[12].ToString()),
                            ListPrice = decimal.Parse(values[13].ToString()),
                            AlertStock = int.Parse(values[14].ToString()),
                            CreatedAt = DateTime.Parse(values[15].ToString()),
                            UpdatedAt = string.IsNullOrEmpty(values[16]?.ToString()) ? (DateTime?)null : DateTime.Parse(values[16].ToString())
                        };
                        list.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting products by category.", ex);
            }
            return list;

        }

        public IEnumerable<Product> Search(string term)
        {
            var list = new List<Product>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Product_Search", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@Term", term) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var p = new Product
                        {
                            ProductId = Guid.Parse(values[0].ToString()),
                            SKU = values[1].ToString(),
                            Barcode = values[2].ToString(),
                            Name = values[3].ToString(),
                            Description = values[4].ToString(),
                            BrandId = Guid.Parse(values[5].ToString()),
                            CategoryId = Guid.Parse(values[6].ToString()),
                            BranchId = Guid.Parse(values[7].ToString()),
                            Volume = string.IsNullOrEmpty(values[8]?.ToString()) ? (decimal?)null : decimal.Parse(values[8].ToString()),
                            VolumeUnit = values[9]?.ToString(),
                            Weight = string.IsNullOrEmpty(values[10]?.ToString()) ? (decimal?)null : decimal.Parse(values[10].ToString()),
                            WeightUnit = values[11]?.ToString(),
                            CostPrice = decimal.Parse(values[12].ToString()),
                            ListPrice = decimal.Parse(values[13].ToString()),
                            AlertStock = int.Parse(values[14].ToString()),
                            CreatedAt = DateTime.Parse(values[15].ToString()),
                            UpdatedAt = string.IsNullOrEmpty(values[16]?.ToString()) ? (DateTime?)null : DateTime.Parse(values[16].ToString())
                        };
                        list.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while searching products.", ex);
            }
            return list;

        }
    }
}
