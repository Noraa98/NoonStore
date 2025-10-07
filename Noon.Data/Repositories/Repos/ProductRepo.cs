using Microsoft.EntityFrameworkCore;
using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;

namespace Noon.Data.Repositories.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly NoonStoreContext _context;
        public ProductRepo(NoonStoreContext context) {
            _context = context;
        }
        public Product GetById(int id)
        {
            return _context.Products
                   .Include(p => p.Supplier)
                   .FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> GetList()
        {
            return _context.Products
                   .Include(p => p.Supplier)
                   .ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }


    }
}
