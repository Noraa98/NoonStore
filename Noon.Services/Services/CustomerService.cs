using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;
using Noon.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _repo;

        public CustomerService(ICustomerRepo repo)
        {
            _repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetCustomerList();
        }

        public Customer FindCustomerByEmail(string email)
        {
            return _repo.FindByEmail(email);
        }

        public List<Customer> SearchCustomersByName(string name)
        {
            return _repo.SearchByName(name);
        }
    }
}
