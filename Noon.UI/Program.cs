using System;
using Noon.Services.Contracts;
namespace Noon.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerService = Factory.GetCustomerService();

            Console.WriteLine("=====================================");
            Console.WriteLine("   🛒 Welcome to Noon Store ");
            Console.WriteLine("=====================================");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Show All Customers");
                Console.WriteLine("2. Search Customer by Name");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-------------------------------------");
                Console.Write("Your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var allCustomers = customerService.GetAllCustomers();
                        Console.WriteLine("\n All Customers:");
                        foreach (var c in allCustomers)
                            Console.WriteLine($"ID: {c.CustomerId} | {c.FullName} | {c.Email} | {c.Phone} | {c.Address}");
                        break;

                    case "2":
                        Console.Write("\nEnter name to search: ");
                        var name = Console.ReadLine();
                        var results = customerService.SearchCustomersByName(name);

                        if (results.Count == 0)
                            Console.WriteLine(" No customers found.");
                        else
                        {
                            Console.WriteLine("\n Search Results:");
                            foreach (var c in results)
                                Console.WriteLine($"ID: {c.CustomerId} | {c.FullName} | {c.Email} | {c.Phone} | {c.Address}");
                        }
                        break;

                    case "3":
                        running = false;
                        Console.WriteLine("\n Thanks for using Noon Store!");
                        break;

                    default:
                        Console.WriteLine(" Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}

