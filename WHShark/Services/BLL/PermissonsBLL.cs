using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DAL.Implementations;
using Services.DomainModel.Security.Composite;
using Services.Services;

namespace Services.BLL
{
    public static class PermissonsBLL
    {
        /// <summary>
        /// Return all families from the repository.
        /// </summary>
        public static IEnumerable<Family> SelectAllFamilies()
        {
            try
            {
                return FamilyRepository.Current.SelectAll();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"PermissonsBLL.SelectAllFamilies failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Return all patents from the repository.
        /// </summary>
        public static IEnumerable<Patent> SelectAllPatents()
        {
            try
            {
                return PatentRepository.Current.SelectAll();
            }
            catch (Exception ex)
            {
                LoggerService.WriteError($"PermissonsBLL.SelectAllPatents failed: {ex.Message}");
                throw;
            }
        }

        public static void UpdateUserPermissions(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            try
            {
                var selectedRoles = user.Permisos.OfType<Family>().ToList();
                var selectedPatents = user.Permisos.OfType<Patent>().ToList();

                var patentsFromRoles = selectedRoles
                                        .SelectMany(f => f.GetChildrens().OfType<Patent>())
                                        .ToList();

                var orphanPatents = selectedPatents
                                    .Where(p => !patentsFromRoles.Any(pr => pr.IdComponent == p.IdComponent))
                                    .ToList();

                var patentsToDelete = patentsFromRoles
                                        .Where(pr => !selectedPatents.Any(sp => sp.IdComponent == pr.IdComponent))
                                        .ToList();

                UserRepository.Current.UpdateUserFamilies(user.IdUser, selectedRoles);

                if (patentsToDelete.Count > 0)
                {
                    var patentIdsToRemove = patentsToDelete.Select(p => p.IdComponent).ToList();
                    UserRepository.Current.DeleteUserPatentsSpecific(user.IdUser, patentIdsToRemove);
                }

                if (orphanPatents.Count > 0)
                {
                    UserRepository.Current.InsertUserPatents(user.IdUser, orphanPatents);
                }
            }
            catch (BusinessException bex)
            {
                LoggerService.WriteWarning(bex.Message);
                throw; 
            }
            catch (Exception ex)
            {
                LoggerService.WriteError("Error updating user permissions: " + ex.Message);
                throw new BusinessException("Unexpected error while updating user permissions.", ex);
            }
        }
    }
}
