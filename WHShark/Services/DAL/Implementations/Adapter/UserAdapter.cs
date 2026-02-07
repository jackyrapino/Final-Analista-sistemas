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

                // Typical expected layout (best-effort):
                // 0 -> Id (Guid), 1 -> Name, 2 -> Password, 3 -> FailedAttempts, 4 -> State (int),
                // 5 -> PasswordResetToken, 6 -> PasswordResetTokenExpires, 7 -> IsAdmin

                int idx = 0;
                if (idx < values.Length && values[idx] != null && Guid.TryParse(values[idx].ToString(), out Guid id))
                {
                    user.IdUser = id;
                }
                idx++;

                if (idx < values.Length && values[idx] != null)
                    user.Name = values[idx].ToString();
                idx++;

                if (idx < values.Length && values[idx] != null)
                    user.Password = values[idx].ToString();
                idx++;

                if (idx < values.Length && values[idx] != null && int.TryParse(values[idx].ToString(), out int fa))
                    user.FailedAttempts = fa;
                idx++;

                if (idx < values.Length && values[idx] != null && int.TryParse(values[idx].ToString(), out int state))
                    user.State = (global::Services.DomainModel.Security.UserState)state;
                idx++;

                if (idx < values.Length && values[idx] != null)
                    user.PasswordResetToken = values[idx].ToString();
                idx++;

                if (idx < values.Length && values[idx] != null && DateTime.TryParse(values[idx].ToString(), out DateTime expires))
                    user.PasswordResetTokenExpires = expires;
                idx++;

                if (idx < values.Length && values[idx] != null && bool.TryParse(values[idx].ToString(), out bool isAdmin))
                    user.IsAdmin = isAdmin;
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
