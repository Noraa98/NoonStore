using Noon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Services.Contracts
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer FindCustomerByEmail(string email);
        List<Customer> SearchCustomersByName(string name);

    }
}
