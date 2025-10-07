using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;
using Noon.Services.Contracts;

namespace Noon.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;

        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo) 
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }
        public IEnumerable<Order> GetList()
        {
            return _orderRepo.GetList();
        }
        public Order GetById(int id)
        {
            return _orderRepo.GetById(id);
        }
        public void Add(Order order)
        {
            // Business logic: Ensure all products in the order exist
            foreach (var item in order.OrderItems)
            {
                var product = _productRepo.GetById(item.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {item.ProductId} does not exist.");
                }
            }
            _orderRepo.Add(order);
        }
        public void Update(Order order)
        {
            _orderRepo.Update(order);
        }
        public void Delete(int id)
        {
            _orderRepo.Delete(id);
        }





    }
}
