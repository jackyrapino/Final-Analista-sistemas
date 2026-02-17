using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> SearchByName(string name);
        Customer GetByEmail(string email);
    }
}
