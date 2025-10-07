using Noon.Data.Models;

namespace Noon.Data.Repositories.Contracts
{
    public interface IProductRepo
    {
        Product GetById(int id);
        IEnumerable<Product> GetList();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
