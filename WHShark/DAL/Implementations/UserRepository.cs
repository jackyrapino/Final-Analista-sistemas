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
    public sealed class UserRepository : IUserRepository
    {
        #region Singleton
        private readonly static UserRepository _instance = new UserRepository();
        public static UserRepository Current => _instance;
        private UserRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";

        public void Add(User obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "User_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@CreatedAt", obj.CreatedAt),
                        new SqlParameter("@Name", (object)obj.Name ?? DBNull.Value)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public void Update(User obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "User_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@UserId", obj.UserId),
                        new SqlParameter("@BranchId", obj.BranchId),
                        new SqlParameter("@CreatedAt", obj.CreatedAt),
                        new SqlParameter("@Name", (object)obj.Name ?? DBNull.Value)
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
                SqlHelper.ExecuteNonQuery(ConnectionName, "User_Delete", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@UserId", id) });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }

        public IEnumerable<User> SelectAll()
        {
            var list = new List<User>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "User_SelectAll", CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var u = new User
                        {
                            UserId = Guid.Parse(values[0].ToString()),
                            BranchId = Guid.Parse(values[1].ToString()),
                            CreatedAt = DateTime.Parse(values[2].ToString()),
                            Name = values[3]?.ToString()
                        };
                        list.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return list;
        }

        public User SelectOne(Guid id)
        {
            User user = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "User_Select", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@UserId", id) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        user = new User
                        {
                            UserId = Guid.Parse(values[0].ToString()),
                            BranchId = Guid.Parse(values[1].ToString()),
                            CreatedAt = DateTime.Parse(values[2].ToString()),
                            Name = values[3]?.ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return user;
        }
    }
}
