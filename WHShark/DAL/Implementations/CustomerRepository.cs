using DAL.Contracts;
using DAL.Tools;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        #region Singleton
        private readonly static CustomerRepository _instance = new CustomerRepository();
        public static CustomerRepository Current => _instance;
        private CustomerRepository() { }
        #endregion

        private const string ConnectionName = "ManagerBusiness";


        public void Add(Customer obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Customer_Insert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                    new SqlParameter("@CustomerId", obj.CustomerId),
                    new SqlParameter("@FirstName", obj.FirstName),
                    new SqlParameter("@LastName", obj.LastName),
                    new SqlParameter("@Email", obj.Email),
                    new SqlParameter("@Phone", obj.Phone),
                    new SqlParameter("@Address", obj.Address),
                    new SqlParameter("@BirthdayDay", (object)obj.BirthdayDay ?? DBNull.Value)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting customer data.", ex);
            }

        }

        public void Update(Customer obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Customer_Update", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                    new SqlParameter("@CustomerId", obj.CustomerId),
                    new SqlParameter("@FirstName", obj.FirstName),
                    new SqlParameter("@LastName", obj.LastName),
                    new SqlParameter("@Email", obj.Email),
                    new SqlParameter("@Phone", obj.Phone),
                    new SqlParameter("@Address", obj.Address),
                    new SqlParameter("@BirthdayDay", (object)obj.BirthdayDay ?? DBNull.Value)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating customer data.", ex);
            }

        }

        public void Delete(Guid id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionName, "Customer_Delete", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                    new SqlParameter("@CustomerId", id)
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting customer data.", ex);
            }

        }

        public IEnumerable<Customer> SelectAll()
        {
            var customers = new List<Customer>();

            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Customer_SelectAll", CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = reader.GetGuid(reader.GetOrdinal("CustomerId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            BirthdayDay = reader.IsDBNull(reader.GetOrdinal("BirthdayDay"))
                                          ? (DateTime?)null
                                          : reader.GetDateTime(reader.GetOrdinal("BirthdayDay"))
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting all customers.", ex);
            }

            return customers;

        }

        public Customer SelectOne(Guid id)
        {
            Customer customer = null;

            try
            {
                using (var reader = SqlHelper.ExecuteReader(ConnectionName, "Customer_SelectOne", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@CustomerId", id) }))
                {
                    if (reader.Read())
                    {
                        customer = new Customer
                        {
                            CustomerId = reader.GetGuid(reader.GetOrdinal("CustomerId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            BirthdayDay = reader.IsDBNull(reader.GetOrdinal("BirthdayDay"))
                                          ? (DateTime?)null
                                          : reader.GetDateTime(reader.GetOrdinal("BirthdayDay"))
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while selecting a customer by id.", ex);
            }

            return customer;

        }

        public IEnumerable<Customer> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Customer GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
