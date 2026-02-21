using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class StockRepository : IStockRepository
    {
        #region Singleton
        private readonly static StockRepository _instance = new StockRepository();
        public static StockRepository Current => _instance;
        private StockRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Stock obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Stock_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@StockId", obj.StockId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@Quantity", obj.Quantity),
                        new SqlParameter("@LastUpdated", obj.LastUpdated)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting stock data.", ex);
            }
        }

        public void Update(Stock obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Stock_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@StockId", obj.StockId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@Quantity", obj.Quantity),
                        new SqlParameter("@LastUpdated", obj.LastUpdated)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating stock data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Stock_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@StockId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting stock data.", ex);
            }
        }

        public IEnumerable<Stock> SelectAll()
        {
            var list = new List<Stock>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Stock_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var s = new Stock
                        {
                            StockId = Guid.Parse(values[0].ToString()),
                            ProductId = Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            LastUpdated = DateTime.Parse(values[4].ToString())
                        };
                        list.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all stocks.", ex);
            }
            return list;
        }

        public IEnumerable<Stock> StockByBranch(Guid branchId)
        {
            var list = new List<Stock>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "StockByBranch", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@BranchId", branchId) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var s = new Stock
                        {
                            StockId = Guid.Parse(values[0].ToString()),
                            ProductId = Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            LastUpdated = DateTime.Parse(values[4].ToString())
                        };
                        list.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting stocks by branch.", ex);
            }
            return list;
        }

        public Stock SelectOne(Guid id)
        {
            Stock stock = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Stock_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@StockId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        stock = new Stock
                        {
                            StockId = Guid.Parse(values[0].ToString()),
                            ProductId = Guid.Parse(values[1].ToString()),
                            BranchId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString()),
                            LastUpdated = DateTime.Parse(values[4].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a stock by id.", ex);
            }
            return stock;
        }

        public int GetAvailableStock(Guid productId, Guid branchId)
        {
            int availableStock = 0;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Stock_GetAvailable", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                new SqlParameter("@ProductId", productId),
                new SqlParameter("@BranchId", branchId)
                    }))
                {
                    if (reader.Read())
                    {
                        availableStock = int.Parse(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting an available  stock by product.", ex);
            }
            return availableStock;
        }

    }
}
