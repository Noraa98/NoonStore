using Noon.Data.Models;

namespace Noon.Data.Repositories.Contracts
{
    public interface ISupplierRepo
    {
        Supplier GetById(int id);
        IEnumerable<Supplier> GetList();
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int id);
    }
}
