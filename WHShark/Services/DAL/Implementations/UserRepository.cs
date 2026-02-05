using Services.DAL.Contracts;
using Services.DomainModel.Security.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations
{
    internal sealed class UserRepository : IGenericRepository<User>
    {
        #region Singleton
        private readonly static UserRepository _instance = new UserRepository();

        public static UserRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private UserRepository()
        {
            //Implement here the initialization code
        }
        #endregion
        public void Add(User obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectAll()
        {
            throw new NotImplementedException();
        }

        public User SelectOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();

        }

        // New stubs used by authentication logic
        public User GetByLoginName(string loginName)
        {
            // Implement data access (e.g. query by loginName)
            throw new NotImplementedException();
        }

        public User GetByPasswordResetToken(string token)
        {
            // Implement data access (e.g. find user by reset token and check expiration)
            throw new NotImplementedException();
        }

        public void SavePasswordResetToken(Guid userId, string token, DateTime expiration)
        {
            // Persist token and expiration for the user
            throw new NotImplementedException();
        }
    }

}
