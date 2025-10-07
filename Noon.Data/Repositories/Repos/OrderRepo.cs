using Microsoft.EntityFrameworkCore;
using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;

namespace Noon.Data.Repositories.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly NoonStoreContext _context;
        public OrderRepo(NoonStoreContext context)
        {
            _context = context;
        }
        public Order GetById(int id)
        {
            return _context.Orders
                   .Include(o => o.Customer)
                   .Include(o => o.OrderItems)
                       .ThenInclude(oi => oi.Product)
                   .FirstOrDefault(o => o.Id == id);
        }
        public IEnumerable<Order> GetList()
        {
            return _context.Orders
                   .Include(o => o.Customer)
                   .Include(o => o.OrderItems)
                       .ThenInclude(oi => oi.Product)
                   .ToList();
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }




    }
}
