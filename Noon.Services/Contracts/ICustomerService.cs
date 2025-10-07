using Noon.Data.Models;

namespace Noon.Services.Contracts
{
    public interface ICustomerService
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetList();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);



    }
}
