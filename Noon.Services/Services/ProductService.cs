using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;
using Noon.Services.Contracts;

namespace Noon.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<Product> GetList()
        {
            return _productRepo.GetList();
        }
        public Product GetById(int id)
        {
            return _productRepo.GetById(id);
        }
        public void Add(Product product)
        {
            _productRepo.Add(product);
        }
        public void Update(Product product)
        {
            _productRepo.Update(product);
        }
        public void Delete(int id)
        {
            _productRepo.Delete(id);
        }



    }
}
