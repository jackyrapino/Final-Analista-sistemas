using Services.DAL.Contracts;
using Services.DomainModel.Security.Composite;
using Services.DAL.Tools;
using Services.DAL.Implementations.Adapter;
using Services.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations
{
    internal sealed class UserRepository : IGenericRepository<User>
    {
        #region Singleton
        private readonly static UserRepository _instance = new UserRepository();

        public static UserRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private UserRepository()
        {
            //Implement here the initialization code
        }
        #endregion
        public void Add(User obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectAll()
        {
            throw new NotImplementedException();
        }

        public User SelectOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            // Persist only fields relevant to authentication: Password, FailedAttempts, State, PasswordResetToken, PasswordResetTokenExpires
            try
            {
                SqlHelper.ExecuteNonQuery("ManagerAuth", "User_Update",
                    System.Data.CommandType.StoredProcedure,
                    new SqlParameter[] {
                        new SqlParameter("@IdUser", obj.IdUser),
                        new SqlParameter("@Password", (object)obj.Password ?? DBNull.Value),
                        new SqlParameter("@FailedAttempts", obj.FailedAttempts),
                        new SqlParameter("@State", (int)obj.State),
                        new SqlParameter("@PasswordResetToken", (object)obj.PasswordResetToken ?? DBNull.Value),
                        new SqlParameter("@PasswordResetTokenExpires", (object)obj.PasswordResetTokenExpires ?? DBNull.Value)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }

        }

        // New stubs used by authentication logic
        public User GetByLoginName(string loginName)
        {
            User user = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader("ManagerAuth", "User_SelectByLoginName", System.Data.CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@LoginName", loginName) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        user = UserAdapter.Current.Adapt(values);

                        // Populate user's permisos via DAL joins: families and patents associated to user
                        // First, load top-level Families and Patents by user
                        // We rely on stored procedures User_Family_Select and User_Patent_Select returning ids

                        // Load user families
                        reader.Close();
                        using (var r2 = SqlHelper.ExecuteReader("ManagerAuth", "User_Family_Select", System.Data.CommandType.StoredProcedure,
                            new SqlParameter[] { new SqlParameter("@IdUser", user.IdUser) }))
                        {
                            object[] vals2 = new object[r2.FieldCount];
                            while (r2.Read())
                            {
                                r2.GetValues(vals2);
                                Guid idFamily = Guid.Parse(vals2[1].ToString());
                                var fam = FamilyRepository.Current.SelectOne(idFamily);
                                if (fam != null)
                                    user.Permisos.Add(fam);
                            }
                        }

                        // Load user patents
                        using (var r3 = SqlHelper.ExecuteReader("ManagerAuth", "User_Patent_Select", System.Data.CommandType.StoredProcedure,
                            new SqlParameter[] { new SqlParameter("@IdUser", user.IdUser) }))
                        {
                            object[] vals3 = new object[r3.FieldCount];
                            while (r3.Read())
                            {
                                r3.GetValues(vals3);
                                Guid idPatent = Guid.Parse(vals3[1].ToString());
                                var pat = PatentRepository.Current.SelectOne(idPatent);
                                if (pat != null)
                                    user.Permisos.Add(pat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return user;
        }

        public User GetByPasswordResetToken(string token)
        {
            User user = null;
            try
            {
                using (var reader = SqlHelper.ExecuteReader("ManagerAuth", "User_SelectByPasswordResetToken", System.Data.CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@Token", token) }))
                {
                    object[] values = new object[reader.FieldCount];
                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        user = UserAdapter.Current.Adapt(values);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
            return user;
        }

        public void SavePasswordResetToken(Guid userId, string token, DateTime expiration)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("ManagerAuth", "User_SavePasswordResetToken",
                    System.Data.CommandType.StoredProcedure,
                    new SqlParameter[] {
                        new SqlParameter("@IdUser", userId),
                        new SqlParameter("@Token", token),
                        new SqlParameter("@Expiration", expiration)
                    });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }
    }

}
