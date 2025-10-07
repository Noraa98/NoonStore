using Microsoft.EntityFrameworkCore;
using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;

namespace Noon.Data.Repositories.Repos
{
    public class SupplierRepo :ISupplierRepo
    {

        private readonly NoonStoreContext _context;

        public SupplierRepo(NoonStoreContext context)
        {
            _context = context;
        }

        // Get all suppliers (with their products)
        public IEnumerable<Supplier> GetList()
        {
            return _context.Suppliers
                   .Include(s => s.Products)
                   .ToList();
        }


        // Get supplier by id
        public Supplier GetById(int id)
        {
            return _context.Suppliers
                   .Include(s => s.Products)
                   .FirstOrDefault(s => s.Id == id);
        }

        // Add new supplier
        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        // Update existing supplier
        public void Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        // Delete supplier by id
        public void Delete(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }




    }
}
