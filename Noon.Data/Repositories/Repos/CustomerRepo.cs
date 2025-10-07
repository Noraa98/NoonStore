using Microsoft.EntityFrameworkCore;
using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;

namespace Noon.Data.Repositories.Repos
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly NoonStoreContext _context;
        public CustomerRepo(NoonStoreContext context)
        {
            _context = context;
        }
        public Customer GetById(int id)
        {
            return _context.Customers
                   .Include(c => c.Orders)
                   .FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Customer> GetList()
        {
            return _context.Customers
                   .Include(c => c.Orders)
                   .ToList();
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

    }
}
