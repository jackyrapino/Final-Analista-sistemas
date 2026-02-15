using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.BLL;
using Services.DomainModel.Security.Composite;

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
    }
}
