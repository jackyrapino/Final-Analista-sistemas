using Services.DAL.Implementations;
using Services.DAL.Factories;
using Services.DomainModel.Security.Composite;
using Services.Services.Extensions;
using System;
using Services.Services; // for LoggerService
using System.Collections.Generic;

namespace Services.BLL
{
    public static class LoginBLL
    {
        private const int MaxFailedAttempts = 3;

        public static User Login(string loginName, string password)
        {
            if (string.IsNullOrWhiteSpace(loginName))
                throw new ArgumentException("loginName is required", nameof(loginName));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("password is required", nameof(password));

            var user = UserRepository.Current.GetByLoginName(loginName);
            if (user == null)
                throw new UsuarioInexistenteException();

            if (user.State == global::Services.DomainModel.Security.UserState.Blocked)
                throw new UsuarioBloqueadoException();

            // If the user is inactive, reject login early
            if (user.State == global::Services.DomainModel.Security.UserState.Inactive)
                throw new UsuarioInactivoException();

            // Verify password first before loading any permissions
            var hashed = global::Services.Services.CryptographyService.HashPassword(password);
            if (!string.Equals(hashed, user.Password, StringComparison.OrdinalIgnoreCase))
            {
                // Incorrect password: increment failed attempts and possibly block
                user.FailedAttempts++;
                if (user.FailedAttempts >= MaxFailedAttempts)
                {
                    user.State = global::Services.DomainModel.Security.UserState.Blocked;
                    // Persist only when user becomes blocked
                    UserRepository.Current.Update(user);
                    LoggerService.WriteWarning($"User '{loginName}' blocked after {user.FailedAttempts} failed login attempts.", loginName);

                    throw new UsuarioBloqueadoException();
                }
                LoggerService.WriteWarning($"Failed login attempt for user '{loginName}' (attempt {user.FailedAttempts}).", loginName);

                // Do not persist simple failed attempt here to avoid unnecessary writes
                throw new PasswordIncorrectaException();
            }

            // Correct password: reset failed attempts (do not persist here to avoid extra write)
            user.FailedAttempts = 0;

            try
            {
                if (user.IsAdmin)
                {
                    var allFamilies = FamilyRepository.Current.SelectAll();
                    foreach (var f in allFamilies)
                        user.Permisos.Add(f);

                    var allPatents = PatentRepository.Current.SelectAll();
                    foreach (var p in allPatents)
                        user.Permisos.Add(p);
                }
                else
                {
                    UserRepository.Current.PopulatePermissions(user);
                }
            }
            catch (Exception ex)
            {
                ex.Handle(ServiceFactory.LoggerRepository as object);
            }

            // If force change required, return user so service/UI can enforce
            if (user.State == global::Services.DomainModel.Security.UserState.ForceChange)
                return user;

            return user;
        }

        public static void ChangePassword(string username, string currentPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username is required", nameof(username));
            if (string.IsNullOrWhiteSpace(currentPassword))
                throw new ArgumentException("currentPassword is required", nameof(currentPassword));
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("newPassword is required", nameof(newPassword));

            var user = UserRepository.Current.GetByLoginName(username);
            if (user == null)
                throw new UsuarioInexistenteException();

            // User must be active to change password
            if (user.State != global::Services.DomainModel.Security.UserState.Active)
                throw new UsuarioInactivoException();

            // Verify current password
            var currentHash = global::Services.Services.CryptographyService.HashPassword(currentPassword);
            if (!string.Equals(currentHash, user.Password, StringComparison.OrdinalIgnoreCase))
            {
                // Incorrect current password: increment failed attempts and possibly block
                user.FailedAttempts++;
                if (user.FailedAttempts >= MaxFailedAttempts)
                {
                    user.State = global::Services.DomainModel.Security.UserState.Blocked;
                    // Persist only when user becomes blocked
                    UserRepository.Current.Update(user);
                    LoggerService.WriteWarning($"User '{username}' blocked after {user.FailedAttempts} failed password-change attempts.", username);

                    throw new UsuarioBloqueadoException();
                }

                LoggerService.WriteWarning($"Failed password-change attempt for user '{username}' (attempt {user.FailedAttempts}).", username);
                throw new PasswordIncorrectaException();
            }

            user.Password = global::Services.Services.CryptographyService.HashPassword(newPassword);
            user.FailedAttempts = 0;
            user.State = global::Services.DomainModel.Security.UserState.Active;

            UserRepository.Current.Update(user);

            LoggerService.WriteInfo($"Password changed successfully for user '{username}'.", username);
        }
        public static IEnumerable<User> SelectAllUsers()
        {
            return UserRepository.Current.SelectAll();
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        public static void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            try
            {
                UserRepository.Current.Add(user);
                LoggerService.WriteInfo($"User added: {user.Username}", user?.Name ?? string.Empty);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred while adding user '{user?.Username}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Update user by delegating to repository and logging the operation.
        /// </summary>
        public static void UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            try
            {
                UserRepository.Current.Update(user);
                LoggerService.WriteInfo($"User updated: {user.Username}", user?.Name ?? string.Empty);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred while updating user '{user?.Username}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Delete a user by id via repository and log the action.
        /// </summary>
        public static void DeleteUser(Guid id)
        {
            try
            {
                UserRepository.Current.Delete(id);
                LoggerService.WriteInfo($"User deleted: {id}", id.ToString());
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred while deleting user '{id}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Return all families
        /// </summary>
        public static IEnumerable<Family> SelectAllFamilies()
        {
            return FamilyRepository.Current.SelectAll();
        }

        /// <summary>
        /// Populate permissions (families and patents) for a given user.
        /// </summary>
        public static void PopulatePermissions(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            try
            {
                UserRepository.Current.PopulatePermissions(user);
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred while populating permissions for user '{user?.Username}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Uses stored procedure User_SelectByLoginName via repository.
        /// Logs exceptions to LoggerService.
        /// </summary>
        public static User ResetPassword(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username is required", nameof(username));

            try
            {
                var user = UserRepository.Current.GetByLoginName(username);
                if (user == null)
                {
                    LoggerService.WriteWarning($"ResetPassword: user not found '{username}'");
                    throw new UsuarioInexistenteException();
                }

                return user;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"An error occurred in ResetPassword for user '{username}': {ex.Message}");
                throw;
            }
        }
    }
}