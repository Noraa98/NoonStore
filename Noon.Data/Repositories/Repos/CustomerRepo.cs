using Microsoft.Data.SqlClient;
using Noon.Data.Models;
using Noon.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Data.Repositories.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=NoonStoreDB;Integrated Security=True;TrustServerCertificate=True;";

        public Customer GetCustomer(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE CustomerId = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                    return null;

                return MapCustomer(dt.Rows[0]);
            }
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> customers = new();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(MapCustomer(row));
                }
            }

            return customers;
        }

        
        public Customer FindByEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE Email = @Email";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Email", email);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                    return null;

                return MapCustomer(dt.Rows[0]);
            }
        }

        public List<Customer> SearchByName(string name)
        {
            List<Customer> customers = new();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE FullName LIKE @name";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + name + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(MapCustomer(row));
                }
            }

            return customers;
        }

        // helper method to map DataRow to Customer object
        private Customer MapCustomer(DataRow row)
        {
            return new Customer
            {
                CustomerId = Convert.ToInt32(row["CustomerId"]),
                FullName = row["FullName"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Phone"].ToString(),
                Address = row["Address"].ToString()
            };
        }
    }
}
