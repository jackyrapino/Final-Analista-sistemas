using Services.DAL.Implementations;
using Services.DAL.Factories;
using Services.DomainModel.Security.Composite;
using Services.Services.Extensions;
using System;
using Services.Services; // for LoggerService

namespace Services.BLL
{
    public static class LoginService
    {
        private const int MaxFailedAttempts = 3;

        public static User Login(string loginName, string password)
        {
            if (string.IsNullOrWhiteSpace(loginName))
                throw new ArgumentException("loginName is required", nameof(loginName));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("password is required", nameof(password));

            // Get user by login name (retrieve basic user record including stored password hash)
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

                    // Log the blocking event
                    LoggerService.WriteWarning($"User '{loginName}' blocked after {user.FailedAttempts} failed login attempts.", loginName);

                    throw new UsuarioBloqueadoException();
                }

                // Log the failed attempt (no DB write)
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
                // log but continue
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
    }
}
