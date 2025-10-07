using Noon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Services.Contracts
{
    public interface ISupplierService
    {
        Supplier GetById(int id);
        IEnumerable<Supplier> GetList();
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int id);

    }
}
