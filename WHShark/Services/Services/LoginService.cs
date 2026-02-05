using Services.DomainModel.Security;
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
                var u = global::Services.BLL.LoginService.Login(loginName, password);

                if (u == null)
                {
                    message = "Credenciales inválidas.";
                    return false;
                }

                if (u.State == global::Services.DomainModel.Security.UserState.ForceChange)
                {
                    user = u;
                    message = "Debe cambiar la contraseña en el primer ingreso.";
                    return false;
                }

                Session.CurrentUser = u;
                LoggerService.WriteInfo($"Inicio de sesión exitoso: {loginName}", u?.Name ?? string.Empty);
                user = u;
                message = "Inicio de sesión exitoso.";
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
                LoggerService.WriteError("Ocurrió un error inesperado al intentar iniciar sesión: " + ex.Message);
                message = "Ocurrió un error inesperado al intentar iniciar sesión.";
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
                    message = "El código ingresado no es válido o ha expirado.";
                    return false;
                }

                repoUser.Password = CryptographyService.HashPassword(newPassword);
                repoUser.FailedAttempts = 0;
                repoUser.State = global::Services.DomainModel.Security.UserState.Active;
                repoUser.PasswordResetToken = null;
                repoUser.PasswordResetTokenExpires = null;

                DAL.Implementations.UserRepository.Current.Update(repoUser);

                LoggerService.WriteInfo("Contraseña restablecida correctamente", repoUser?.Name ?? string.Empty);
                message = "Contraseña restablecida correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Ocurrió un error al restablecer la contraseña: " + ex.Message);
                message = "Ocurrió un error al restablecer la contraseña.";
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
    }
}
