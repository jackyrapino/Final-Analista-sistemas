using Services.DAL.Contracts;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.Adapter
{
    public sealed class UserAdapter : IAdapter<User>
    {
        #region Singleton
        private readonly static UserAdapter _instance = new UserAdapter();

        public static UserAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private UserAdapter()
        {
            //Implement here the initialization code
        }
        #endregion
        public User Adapt(object[] values)
        {
            // Map common user fields defensively - stored procedure may return more/less columns
            var user = new User();

            try
            {
                if (values == null || values.Length == 0)
                    return user;

                // 0 -> Id (Guid)
                // 1 -> Name (display name) -- secondary
                // 2 -> Username (login name) -- prefer this as Name if present
                // 3 -> PasswordHash
                // 4 -> State (int)
                // 5 -> CreatedAt (DateTime) 

                // Id
                if (values.Length > 0 && values[0] != null && Guid.TryParse(values[0].ToString(), out Guid id))
                    user.IdUser = id;

                if (values.Length > 2 && values[2] != null && !string.IsNullOrWhiteSpace(values[2].ToString()))
                {
                    user.Name = values[2].ToString();
                }
                else if (values.Length > 1 && values[1] != null)
                {
                    user.Name = values[1].ToString();
                }

                // PasswordHash
                if (values.Length > 3 && values[3] != null)
                    user.Password = values[3].ToString();

                // State
                if (values.Length > 4 && values[4] != null && int.TryParse(values[4].ToString(), out int state))
                    user.State = (global::Services.DomainModel.Security.UserState)state;

              
                // Initialize defaults
                user.FailedAttempts = 0;
                user.IsAdmin = false;
            }
            catch
            {
                // Swallow mapping errors - return partially hydrated user
            }

            // Permisos will be populated by higher-level repositories/adapters when needed
            return user;
        }
    }
}
