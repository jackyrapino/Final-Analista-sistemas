using Services.DomainModel.Security.Composite;
using Services.BLL;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public static class LoginService
    {
        private const int MaxFailedAttempts = 3;

        public static bool Login(User user)
        {
            return false;
        }

        public static bool TryLogin(string loginName, string password, out User user, out string message)
        {
            user = null;
            message = string.Empty;

            try
            {
                // Delegate authentication to BLL
                var u = global::Services.BLL.LoginBLL.Login(loginName, password);

                if (u == null)
                {
                    message = "Invalid credentials.";
                    return false;
                }

                if (u.State == global::Services.DomainModel.Security.UserState.ForceChange)
                {
                    user = u;
                    message = "Password change required on first login.";
                    return false;
                }

                Session.CurrentUser = u;
                LoggerService.WriteInfo($"Login successful: {loginName}", u?.Name ?? string.Empty);
                user = u;
                message = "Login successful.";
                return true;
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;

                return false;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An unexpected error occurred while attempting to login: " + ex.Message);
                message = "An unexpected error occurred while attempting to login.";
                return false;
            }
        }

       
        public static bool ChangePassword(string username, string currentPassword, string newPassword, out string message)
        {
            message = string.Empty;
            try
            {
                global::Services.BLL.LoginBLL.ChangePassword(username, currentPassword, newPassword);
                LoggerService.WriteInfo($"Password changed for user: {username}", username);
                message = "Password changed successfully.";
                return true;
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);

                if (bex is global::Services.BLL.UsuarioInexistenteException)
                    message = "User does not exist.";
                else if (bex is global::Services.BLL.PasswordIncorrectaException)
                    message = "Incorrect password.";
                else if (bex is global::Services.BLL.UsuarioBloqueadoException)
                    message = "User is blocked.";
                else if (bex is global::Services.BLL.UsuarioInactivoException)
                    message = "User is inactive.";
                else
                    message = bex.Message;

                return false;
            }
            catch (Exception ex)
            {
                // Unexpected errors - log in English
                LoggerService.WriteError("An error occurred while changing the password: " + ex.Message);
                message = "An error occurred while changing the password.";
                return false;
            }
        }

        public static User FindUserForReset(string username, out string message)
        {
            message = string.Empty;

            try
            {
                var u = global::Services.BLL.LoginBLL.ResetPassword(username);
                if (u == null)
                {
                    message = "User does not exist.";
                    return null;
                }
                if (u.State == global::Services.DomainModel.Security.UserState.ForceChange)
                {
                    message = "You can change your password.";
                    return u;
                }

                return null;
            }
            catch (global::Services.BLL.UsuarioInexistenteException)
            {
                message = "User does not exist.";
                return null;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while looking up user for reset: " + ex.Message);
                message = "An unexpected error occurred while processing the request.";
                return null;
            }
        }

        // New: expose list of users to UI by delegating to BLL
        public static IEnumerable<User> ListAllUsers(out string message)
        {
            message = string.Empty;
            try
            {
                var users = global::Services.BLL.LoginBLL.SelectAllUsers();
                return users ?? new List<User>();
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;
                return new List<User>();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while retrieving users: " + ex.Message);
                message = "An unexpected error occurred while retrieving users.";
                return new List<User>();
            }
        }

        public static bool AddUser(User user, out string message)
        {
            message = string.Empty;
            try
            {
                global::Services.BLL.LoginBLL.AddUser(user);
                LoggerService.WriteInfo($"User added: {user?.Username}", user?.Name ?? string.Empty);
                message = "User added successfully.";
                return true;
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;
                return false;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while adding the user: " + ex.Message);
                message = "An error occurred while adding the user.";
                return false;
            }
        }

        public static bool UpdateUser(User user, out string message)
        {
            message = string.Empty;
            try
            {
                global::Services.BLL.LoginBLL.UpdateUser(user);
                LoggerService.WriteInfo($"User updated: {user?.Username}", user?.Name ?? string.Empty);
                message = "User updated successfully.";
                return true;
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;
                return false;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while updating the user: " + ex.Message);
                message = "An error occurred while updating the user.";
                return false;
            }
        }

        public static bool DeleteUser(Guid id, out string message)
        {
            message = string.Empty;
            try
            {
                global::Services.BLL.LoginBLL.DeleteUser(id);
                LoggerService.WriteInfo($"User deleted: {id}", id.ToString());
                message = "User deleted successfully.";
                return true;
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;
                return false;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while deleting the user: " + ex.Message);
                message = "An error occurred while deleting the user.";
                return false;
            }
        }

        public static DomainModel.Security.Composite.Patent SelectOnePatent(Guid id)
        {
            return DAL.Implementations.PatentRepository.Current.SelectOne(id);
        }

        public static User SelectOneUser(Guid id)
        {
            return DAL.Implementations.UserRepository.Current.SelectOne(id);
        }

        public static IEnumerable<DomainModel.Security.Composite.Patent> SelectAllPatents()
        {
            return DAL.Implementations.PatentRepository.Current.SelectAll();
        }

        public static DomainModel.Security.Composite.Family SelectOneFamily(Guid id)
        {
            return DAL.Implementations.FamilyRepository.Current.SelectOne(id);
        }

        // New: expose list of families to UI by delegating to BLL
        public static IEnumerable<Family> ListAllFamilies(out string message)
        {
            message = string.Empty;
            try
            {
                var families = global::Services.BLL.LoginBLL.SelectAllFamilies();
                return families ?? new List<Family>();
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;
                return new List<Family>();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while retrieving families: " + ex.Message);
                message = "An unexpected error occurred while retrieving families.";
                return new List<Family>();
            }
        }
    }
}
