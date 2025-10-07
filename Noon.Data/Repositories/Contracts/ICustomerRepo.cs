using Noon.Data.Models;

namespace Noon.Data.Repositories.Contracts
{
    public interface ICustomerRepo
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetList();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);

    }
}
