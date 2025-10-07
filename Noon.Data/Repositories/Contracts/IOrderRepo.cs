using Noon.Data.Models;

namespace Noon.Data.Repositories.Contracts
{
    public interface IOrderRepo
    {
        Order GetById(int id);
        IEnumerable<Order> GetList();
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);

    }
}
