using Noon.Data.Models;

namespace Noon.Services.Contracts
{
    public interface IProductService
    {
        Product GetById(int id);
        IEnumerable<Product> GetList();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}
