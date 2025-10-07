using Microsoft.EntityFrameworkCore;
using Noon.Data;
using Noon.Data.Repositories.Contracts;
using Noon.Data.Repositories.Repos;
using Noon.Services.Contracts;
using Noon.Services.Services;

namespace Noon.UI
{
    public static class Factory
    {
        public static NoonStoreContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<NoonStoreContext>()
                .UseSqlServer("Server=.;Database=NoonStoreDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            return new NoonStoreContext(options);
        }

        //Repository Creators
        public static ICustomerRepo CreateCustomerRepo(NoonStoreContext context)
            => new CustomerRepo(context);

        public static IProductRepo CreateProductRepo(NoonStoreContext context)
            => new ProductRepo(context);

        public static IOrderRepo CreateOrderRepo(NoonStoreContext context)
            => new OrderRepo(context);

        public static ISupplierRepo CreateSupplierRepo(NoonStoreContext context)
            => new SupplierRepo(context);

        //  Service Creators
        public static ICustomerService CreateCustomerService(NoonStoreContext context)
            => new CustomerService(CreateCustomerRepo(context));

        public static IProductService CreateProductService(NoonStoreContext context)
            => new ProductService(CreateProductRepo(context));

        public static IOrderService CreateOrderService(NoonStoreContext context)
            => new OrderService(CreateOrderRepo(context), CreateProductRepo(context));

        public static ISupplierService CreateSupplierService(NoonStoreContext context)
            => new SupplierService(CreateSupplierRepo(context));

        //  Unified entry point (optional helper)
        public static (NoonStoreContext Context,
                       ICustomerService CustomerService,
                       IProductService ProductService,
                       IOrderService OrderService,
                       ISupplierService SupplierService)
        CreateAll()
        {
            var context = CreateContext();
            return (
                context,
                CreateCustomerService(context),
                CreateProductService(context),
                CreateOrderService(context),
                CreateSupplierService(context)
            );
        }
    }
}
