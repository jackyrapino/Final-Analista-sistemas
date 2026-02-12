using Services.DAL.Implementations;
using Services.DAL.Factories;
using Services.DomainModel.Security.Composite;
using Services.Services.Extensions;
using System;

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

            // Verify password first before loading any permissions
            var hashed = global::Services.Services.CryptographyService.HashPassword(password);
            if (!string.Equals(hashed, user.Password, StringComparison.OrdinalIgnoreCase))
            {
                // Incorrect password: increment failed attempts and possibly block
                user.FailedAttempts++;
                if (user.FailedAttempts >= MaxFailedAttempts)
                {
                    user.State = global::Services.DomainModel.Security.UserState.Blocked;
                    UserRepository.Current.Update(user);
                    throw new UsuarioBloqueadoException();
                }
                else
                {
                    UserRepository.Current.Update(user);
                    throw new PasswordIncorrectaException();
                }
            }

            // Correct password: reset failed attempts
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
    }
}
