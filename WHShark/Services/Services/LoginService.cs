using Services.DomainModel.Security;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public static class LoginService
    {

        public static bool Login(User user)
        {
            return false;
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
