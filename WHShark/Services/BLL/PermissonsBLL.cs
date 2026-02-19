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

                // Build list of patent ids implied by newly selected roles
                var patentsFromRoles = new List<Patent>();
                foreach (var f in selectedRoles)
                {
                    CollectPatentsFromFamily(f, patentsFromRoles);
                }

                var patentsFromRolesIds = new HashSet<Guid>(patentsFromRoles.Select(p => p.IdComponent));
                var selectedPatentIds = new HashSet<Guid>(selectedPatents.Select(p => p.IdComponent));

                // Prepare current DB state for this user so we can diff correctly
                var dbUser = new User { IdUser = user.IdUser, Permisos = new List<Component>() };
                try
                {
                    UserRepository.Current.PopulatePermissions(dbUser);
                }
                catch (Exception ex)
                {
                    LoggerService.WriteError($"Failed to load existing permissions for user {user.IdUser}: {ex.Message}");
                    throw;
                }

                var dbPatentIds = new HashSet<Guid>(dbUser.Permisos.OfType<Patent>().Select(p => p.IdComponent));

                // Effective patents the user should have after this update (from selected roles + selected direct patents)
                var newEffectivePatentIds = new HashSet<Guid>(patentsFromRolesIds.Union(selectedPatentIds));

                // Patents that exist in DB but are NOT in the new effective list -> should be removed
                var patentIdsToRemove = dbPatentIds.Where(id => !newEffectivePatentIds.Contains(id)).ToList();

                // Patents that were selected directly (orphan patents) and are not already present in DB -> should be inserted
                var orphanPatents = selectedPatents
                                    .Where(p => !patentsFromRolesIds.Contains(p.IdComponent))
                                    .ToList();

                var orphanPatentsToInsert = orphanPatents
                                             .Where(p => !dbPatentIds.Contains(p.IdComponent))
                                             .ToList();

                // Update families (this implementation replaces existing families with the provided list)
                UserRepository.Current.UpdateUserFamilies(user.IdUser, selectedRoles);

                if (patentIdsToRemove.Count > 0)
                {
                    UserRepository.Current.DeleteUserPatentsSpecific(user.IdUser, patentIdsToRemove);
                }

                if (orphanPatentsToInsert.Count > 0)
                {
                    UserRepository.Current.InsertUserPatents(user.IdUser, orphanPatentsToInsert);
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

        private static void CollectPatentsFromFamily(Family family, List<Patent> outList)
        {
            if (family == null) return;

            foreach (var child in family.GetChildrens())
            {
                if (child == null) continue;
                if (child.ChildrenCount() == 0)
                {
                    var p = child as Patent;
                    if (p != null && !outList.Exists(x => x.IdComponent == p.IdComponent))
                        outList.Add(p);
                }
                else
                {
                    var childFam = child as Family;
                    if (childFam != null)
                        CollectPatentsFromFamily(childFam, outList);
                }
            }
        }
    }
}
