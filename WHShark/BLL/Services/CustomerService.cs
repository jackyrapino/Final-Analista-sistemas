using BLL.Services.Contracts;
using DAL.Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public DateTime? GetBirthday(Guid customerId)
        {
            var customer = _customerRepository.SelectOne(customerId);
            return customer?.BirthdayDay;
        }

        public Customer GetCustomer(Guid customerId)
        {
            return _customerRepository.SelectOne(customerId);
        }
    }

}
