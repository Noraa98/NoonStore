using Noon.Data.Repositories.Contracts;
using Noon.Data.Repositories.Repos;
using Noon.Services.Contracts;
using Noon.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.UI
{
    internal static class Factory
    {
        public static ICustomerRepo GetCustomerRepo()
        {
            return new CustomerRepo();
        }

        public static ICustomerService GetCustomerService()
        {
            return new CustomerService(GetCustomerRepo());
        }

    }
}
