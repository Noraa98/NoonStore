using Noon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Data.Repositories.Contracts
{
    public interface ICustomerRepo
    {
        Customer GetCustomer(int id);
        List<Customer> GetCustomerList();
        Customer FindByEmail(string email);
        List<Customer> SearchByName(string name);
    }
}
