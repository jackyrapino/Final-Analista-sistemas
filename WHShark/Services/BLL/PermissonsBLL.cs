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
    }
}
