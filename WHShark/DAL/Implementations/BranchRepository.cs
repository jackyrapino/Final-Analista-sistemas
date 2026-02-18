using System;
using System.Collections.Generic;
using DAL.Contracts;
using DomainModel;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class BranchRepository : IBranchRepository
    {
        #region Singleton
        private readonly static BranchRepository _instance = new BranchRepository();
        public static BranchRepository Current => _instance;
        private BranchRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(Branch obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Branch_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Address", obj.Address),
                        new SqlParameter("@IsWeb", obj.IsWeb)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting branch data.", ex);
            }
        }

        public void Update(Branch obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Branch_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Address", obj.Address),
                        new SqlParameter("@IsWeb", obj.IsWeb)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating branch data.", ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Branch_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@BranchId", id) });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting branch data.", ex);
            }
        }

        public IEnumerable<Branch> SelectAll()
        {
            var list = new List<Branch>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Branch_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var b = new Branch
                        {
                            BranchId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Address = values[2].ToString(),
                            IsWeb = bool.Parse(values[3].ToString()),
                            CreatedAt = DateTime.Parse(values[4].ToString())
                        };
                        list.Add(b);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all branches.", ex);
            }
            return list;
        }

        public Branch SelectOne(Guid id)
        {
            Branch branch = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Branch_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@BranchId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        branch = new Branch
                        {
                            BranchId = Guid.Parse(values[0].ToString()),
                            Name = values[1].ToString(),
                            Address = values[2].ToString(),
                            IsWeb = bool.Parse(values[3].ToString()),
                            CreatedAt = DateTime.Parse(values[4].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting branch by id.", ex);
            }
            return branch;
        }
    }
}
