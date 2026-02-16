using Services.BLL;
using Services.DAL.Implementations;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public static class PermissionService
    {
        public static IEnumerable<Family> ListAllRoles(out string message)
        {
            message = string.Empty;
            try
            {
                var families = PermissonsBLL.SelectAllFamilies();
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
                LoggerService.WriteError("An error occurred while retrieving roles: " + ex.Message);
                message = "An unexpected error occurred while retrieving roles.";
                return new List<Family>();
            }
        }

        public static IEnumerable<Patent> ListAllPermissions(out string message)
        {
            message = string.Empty;
            try
            {
                var patents = PermissonsBLL.SelectAllPatents();
                return patents ?? new List<Patent>();
            }
            catch (global::Services.BLL.BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                message = bex.Message;
                return new List<Patent>();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("An error occurred while retrieving permissions: " + ex.Message);
                message = "An unexpected error occurred while retrieving permissions.";
                return new List<Patent>();
            }
        }

        public static bool UpdateUserPermissions(User user, out string message)
        {
            message = string.Empty;
            if (user == null)
            {
                message = "User is required.";
                return false;
            }

            try
            {
                global::Services.BLL.PermissonsBLL.UpdateUserPermissions(user);
                LoggerService.WriteInfo($"Permissions updated for user: {user.Username}", user.Username);
                message = "Permissions updated successfully.";
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
                LoggerService.WriteError("An error occurred while updating user permissions: " + ex.Message);
                message = "An unexpected error occurred while updating permissions.";
                return false;
            }
        }
    }
}
