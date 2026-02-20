using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Guid customerId);
        IEnumerable<Customer> SelectAll();
        Customer SelectOne(Guid customerId);
        IEnumerable<Customer> SearchByName(string name);
        Customer GetByEmail(string email);
        DateTime? GetBirthday(Guid customerId);
        Customer GetCustomer(Guid customerId);
    }

}
