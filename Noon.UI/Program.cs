using System;
using Noon.Data.Models;
using System.Numerics;
using Noon.Services.Contracts;
namespace Noon.UI
{
        internal class Program
        {
            static void Main(string[] args)
            {
                using var ctx = Factory.CreateContext();
                ctx.Database.EnsureCreated();

                var productService = Factory.CreateProductService(ctx);
                var customerService = Factory.CreateCustomerService(ctx);
                var orderService = Factory.CreateOrderService(ctx);
                var supplierService = Factory.CreateSupplierService(ctx);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("==========================================");
                    Console.WriteLine("🛒 Welcome to Noon Store");
                    Console.WriteLine("==========================================");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Create Customer");
                    Console.WriteLine("2. Create Order");
                    Console.WriteLine("3. Create Supplier");
                    Console.WriteLine("4. View Products and Supplier name");
                    Console.WriteLine("5. View Customers and their Orders");
                    Console.WriteLine("6. View Orders with their Products");
                    Console.WriteLine("7. Create Product");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("==========================================");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CreateCustomer(customerService);
                            break;
                        case "2":
                            CreateOrder(orderService, customerService, productService);
                            break;
                        case "3":
                            CreateSupplier(supplierService);
                            break;
                        case "4":
                            ViewProducts(productService);
                            break;
                        case "5":
                            ViewCustomersAndOrders(customerService);
                            break;
                        case "6":
                            ViewOrdersWithProducts(orderService);
                            break;
                        case "7":
                            CreateProduct(productService, supplierService);
                            break;
                        case "0":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }

                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }

            // Create Customer
            static void CreateCustomer(ICustomerService customerService)
            {
                Console.Clear();
                Console.Write("Enter customer name: ");
                var name = Console.ReadLine();

                Console.Write("Enter customer email: ");
                var email = Console.ReadLine();

                customerService.Add(new Customer { FullName = name, Email = email });
                Console.WriteLine(" Customer created successfully!");
            }

            // Create Order
            static void CreateOrder(IOrderService orderService, ICustomerService customerService, IProductService productService)
            {
                Console.Clear();

                Console.Write("Enter Customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int custId))
                {
                    Console.WriteLine(" Invalid input!");
                    return;
                }

                var customer = customerService.GetById(custId);
                if (customer == null)
                {
                    Console.WriteLine(" Customer not found!");
                    return;
                }

                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int prodId))
                {
                    Console.WriteLine(" Invalid input!");
                    return;
                }

                var product = productService.GetById(prodId);
                if (product == null)
                {
                    Console.WriteLine(" Product not found!");
                    return;
                }

                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                {
                    Console.WriteLine(" Invalid quantity!");
                    return;
                }

                var order = new Order
                {
                    CustomerId = custId,
                    TotalAmount = (int)(product.Price * qty),
                    OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = prodId,
                        Quantity = qty,
                        UnitPrice = product.Price
                    }
                }
                };

                orderService.Add(order);
                Console.WriteLine(" Order created successfully!");
            }

            // Create Supplier
            static void CreateSupplier(ISupplierService supplierService)
            {
                Console.Clear();
                Console.Write("Enter supplier name: ");
                var name = Console.ReadLine();

                supplierService.Add(new Supplier { Name = name });
                Console.WriteLine(" Supplier created successfully!");
            }

            // View Products
            static void ViewProducts(IProductService productService)
            {
                Console.Clear();
                Console.WriteLine(" Products and Supplier:");
                var products = productService.GetList();

                if (!products.Any())
                {
                    Console.WriteLine(" No products found.");
                    return;
                }

                foreach (var p in products)
                    Console.WriteLine($"[{p.Id}] {p.Name} - {p.Price} EGP - Supplier: {p.Supplier?.Name ?? "N/A"}");
            }

            // View Customers and their Orders
            static void ViewCustomersAndOrders(ICustomerService customerService)
            {
                Console.Clear();
                Console.WriteLine(" Customers and their Orders:");
                var customers = customerService.GetList();

                foreach (var c in customers)
                {
                    Console.WriteLine($"\n {c.FullName} ({c.Email})");
                    if (c.Orders != null && c.Orders.Any())
                    {
                        foreach (var o in c.Orders)
                            Console.WriteLine($"    Order #{o.Id} - Date: {o.OrderedAt} - Total: {o.TotalAmount} EGP");
                    }
                    else
                    {
                        Console.WriteLine("    No orders yet.");
                    }
                }
            }

            // 6 View Orders and their Products
            static void ViewOrdersWithProducts(IOrderService orderService)
            {
                Console.Clear();
                Console.WriteLine(" Orders and their Products:");
                var orders = orderService.GetList();

                foreach (var o in orders)
                {
                    Console.WriteLine($"\nOrder #{o.Id} - CustomerId: {o.CustomerId}");
                    foreach (var item in o.OrderItems)
                    {
                        Console.WriteLine($"   • {item.Product?.Name} - {item.UnitPrice} EGP × {item.Quantity}");
                    }
                    Console.WriteLine($"   Total: {o.TotalAmount} EGP");
                }
            }

            // 7️ Create Product
            static void CreateProduct(IProductService productService, ISupplierService supplierService)
            {
                Console.Clear();
                Console.Write("Enter product name: ");
                var name = Console.ReadLine();

                Console.Write("Enter product price: ");
                if (!decimal.TryParse(Console.ReadLine(), out var price))
                {
                    Console.WriteLine(" Invalid price!");
                    return;
                }

                var suppliers = supplierService.GetList();
                if (!suppliers.Any())
                {
                    Console.WriteLine(" No suppliers found! Please create one first.");
                    return;
                }

                Console.WriteLine("\nAvailable Suppliers:");
                foreach (var s in suppliers)
                    Console.WriteLine($"[{s.Id}] {s.Name}");

                Console.Write("Enter Supplier ID: ");
                if (!int.TryParse(Console.ReadLine(), out var supplierId))
                {
                    Console.WriteLine(" Invalid supplier ID!");
                    return;
                }

                var supplier = supplierService.GetById(supplierId);
                if (supplier == null)
                {
                    Console.WriteLine(" Supplier not found!");
                    return;
                }

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    SupplierId = supplierId
                };

                productService.Add(product);
                Console.WriteLine(" Product created successfully!");
            }
        }
}
       

