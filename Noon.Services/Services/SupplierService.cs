using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;
using Noon.Services.Contracts;

namespace Noon.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepo _repo;
        public SupplierService(ISupplierRepo repo)
        {
            _repo = repo;
        }
        public IEnumerable<Supplier> GetList()
        {
            return _repo.GetList();
        }
        public Supplier GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Add(Supplier supplier)
        {
            _repo.Add(supplier);
        }
        public void Update(Supplier supplier)
        {
            _repo.Update(supplier);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }


    }
}
