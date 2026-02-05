using Services.DAL.Implementations;
using Services.DAL.Factories;
using Services.DomainModel.Security.Composite;
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

            // Get user by login name
            var user = UserRepository.Current.GetByLoginName(loginName);
            if (user == null)
                throw new UsuarioInexistenteException();

            if (user.State == global::Services.DomainModel.Security.UserState.Blocked)
                throw new UsuarioBloqueadoException();

            var hashed = global::Services.Services.CryptographyService.HashPassword(password);
            if (!string.Equals(hashed, user.Password, StringComparison.OrdinalIgnoreCase))
            {
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

            // Correct password
            user.FailedAttempts = 0;
            UserRepository.Current.Update(user);

            // If force change required, return user so service/UI can enforce
            if (user.State == global::Services.DomainModel.Security.UserState.ForceChange)
                return user;

            return user;
        }
    }
}
