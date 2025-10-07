using Noon.Data.Models;

namespace Noon.Services.Contracts
{
    public interface IOrderService
    {
        Order GetById(int id);
        IEnumerable<Order> GetList();
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);


    }
}
