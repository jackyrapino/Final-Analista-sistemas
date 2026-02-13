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

        public static bool ResetPassword(string token, string newPassword, out string message)
        {
            message = string.Empty;
            try
            {
                var repoUser = DAL.Implementations.UserRepository.Current.GetByPasswordResetToken(token);
                if (repoUser == null)
                {
                    message = "The provided code is invalid or has expired.";
                    return false;
                }

                repoUser.Password = CryptographyService.HashPassword(newPassword);
                repoUser.FailedAttempts = 0;
                repoUser.State = global::Services.DomainModel.Security.UserState.Active;

                DAL.Implementations.UserRepository.Current.Update(repoUser);

                // Log in English
                LoggerService.WriteInfo("Password reset successfully", repoUser?.Name ?? string.Empty);
                message = "Password reset successfully.";
                return true;
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                // Map known business exceptions to English
                if (bex is global::Services.BLL.UsuarioInexistenteException)
                    message = "User does not exist.";
                else
                    message = bex.Message;
                return false;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while resetting the password: " + ex.Message);
                message = "An error occurred while resetting the password.";
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
    }
}
