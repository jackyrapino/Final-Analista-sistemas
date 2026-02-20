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

        // convenience ctor using repository singleton
        public CustomerService() : this(DAL.Implementations.CustomerRepository.Current) { }

        public void Add(Customer customer)
        {
            try
            {
                if (customer == null) throw new ArgumentNullException(nameof(customer));
                if (customer.CustomerId == Guid.Empty) customer.CustomerId = Guid.NewGuid();
                customer.CreatedAt = DateTime.Now;
                _customerRepository.Add(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer.", ex);
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                if (customer == null) throw new ArgumentNullException(nameof(customer));
                _customerRepository.Update(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer.", ex);
            }
        }

        public void Delete(Guid customerId)
        {
            try
            {
                _customerRepository.Delete(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer.", ex);
            }
        }

        public IEnumerable<Customer> SelectAll()
        {
            try
            {
                return _customerRepository.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers.", ex);
            }
        }

        public Customer SelectOne(Guid customerId)
        {
            try
            {
                return _customerRepository.SelectOne(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer.", ex);
            }
        }

        public IEnumerable<Customer> SearchByName(string name)
        {
            try
            {
                return _customerRepository.SearchByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching customers by name.", ex);
            }
        }

        public Customer GetByEmail(string email)
        {
            try
            {
                return _customerRepository.GetByEmail(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer by email.", ex);
            }
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
