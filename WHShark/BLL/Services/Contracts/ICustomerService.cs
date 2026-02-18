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
        DateTime? GetBirthday(Guid customerId);
        Customer GetCustomer(Guid customerId);
    }

}
