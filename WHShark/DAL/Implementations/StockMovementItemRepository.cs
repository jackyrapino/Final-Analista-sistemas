using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class StockMovementItemRepository : IStockMovementItemRepository
    {
        #region Singleton
        private readonly static StockMovementItemRepository _instance = new StockMovementItemRepository();
        public static StockMovementItemRepository Current => _instance;
        private StockMovementItemRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(StockMovementItem obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "StockMovementItem_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MovementItemId", obj.MovementItemId),
                        new SqlParameter("@MovementId", obj.MovementId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@Quantity", obj.Quantity)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting stock movement item data.", ex);
            }
        }

        public void Update(StockMovementItem obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "StockMovementItem_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MovementItemId", obj.MovementItemId),
                        new SqlParameter("@MovementId", obj.MovementId),
                        new SqlParameter("@ProductId", obj.ProductId),
                        new SqlParameter("@Quantity", obj.Quantity)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating stock movement item data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "StockMovementItem_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@MovementItemId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting stock movement item data.", ex);
            }
        }

        public IEnumerable<StockMovementItem> SelectAll()
        {
            var list = new List<StockMovementItem>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "StockMovementItem_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var item = new StockMovementItem
                        {
                            MovementItemId = Guid.Parse(values[0].ToString()),
                            MovementId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString())
                        };
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all stock movement items.", ex);
            }
            return list;
        }

        public StockMovementItem SelectOne(Guid id)
        {
            StockMovementItem item = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "StockMovementItem_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@MovementItemId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        item = new StockMovementItem
                        {
                            MovementItemId = Guid.Parse(values[0].ToString()),
                            MovementId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a stock movement item by id.", ex);
            }
            return item;
        }

        public IEnumerable<StockMovementItem> GetByMovement(Guid movementId)
        {
            var list = new List<StockMovementItem>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "StockMovementItem_GetByMovement", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@MovementId", movementId) }))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var item = new StockMovementItem
                        {
                            MovementItemId = Guid.Parse(values[0].ToString()),
                            MovementId = Guid.Parse(values[1].ToString()),
                            ProductId = Guid.Parse(values[2].ToString()),
                            Quantity = int.Parse(values[3].ToString())
                        };
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting stock movement items by movement id.", ex);
            }
            return list;
        }
    }
}
