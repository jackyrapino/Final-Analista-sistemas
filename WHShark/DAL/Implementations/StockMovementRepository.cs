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
    public sealed class StockMovementRepository : IStockMovementRepository
    {
        #region Singleton
        private readonly static StockMovementRepository _instance = new StockMovementRepository();
        public static StockMovementRepository Current => _instance;
        private StockMovementRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(StockMovement obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "StockMovement_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MovementId", obj.MovementId),
                        new SqlParameter("@FromBranchId", obj.FromBranchId),
                        new SqlParameter("@ToBranchId", obj.ToBranchId),
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@Description", (object)obj.Description ?? DBNull.Value),
                        new SqlParameter("@MovementDate", obj.MovementDate),
                        new SqlParameter("@Comments", (object)obj.Comments ?? DBNull.Value),
                        new SqlParameter("@Status", obj.Status)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public void Update(StockMovement obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "StockMovement_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@MovementId", obj.MovementId),
                        new SqlParameter("@FromBranchId", obj.FromBranchId),
                        new SqlParameter("@ToBranchId", obj.ToBranchId),
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@Description", (object)obj.Description ?? DBNull.Value),
                        new SqlParameter("@MovementDate", obj.MovementDate),
                        new SqlParameter("@Comments", (object)obj.Comments ?? DBNull.Value),
                        new SqlParameter("@Status", obj.Status)
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
                SqlHelper.ExecuteNonQuery(ConnectionName, "StockMovement_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@MovementId", id) });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public IEnumerable<StockMovement> SelectAll()
        {
            var list = new List<StockMovement>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "StockMovement_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var s = new StockMovement
                        {
                            MovementId = Guid.Parse(values[0].ToString()),
                            FromBranchId = Guid.Parse(values[1].ToString()),
                            ToBranchId = Guid.Parse(values[2].ToString()),
                            UserId = Guid.Parse(values[3].ToString()),
                            Description = values[4]?.ToString(),
                            MovementDate = DateTime.Parse(values[5].ToString()),
                            Comments = values[6]?.ToString(),
                            Status = values[7]?.ToString()
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

        public StockMovement SelectOne(Guid id)
        {
            StockMovement sm = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "StockMovement_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@MovementId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        sm = new StockMovement
                        {
                            MovementId = Guid.Parse(values[0].ToString()),
                            FromBranchId = Guid.Parse(values[1].ToString()),
                            ToBranchId = Guid.Parse(values[2].ToString()),
                            UserId = Guid.Parse(values[3].ToString()),
                            Description = values[4]?.ToString(),
                            MovementDate = DateTime.Parse(values[5].ToString()),
                            Comments = values[6]?.ToString(),
                            Status = values[7]?.ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return sm;
        }
    }
}
