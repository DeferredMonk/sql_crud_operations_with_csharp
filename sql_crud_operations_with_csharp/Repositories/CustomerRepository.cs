﻿using Microsoft.Data.SqlClient;
using sql_crud_operations_with_csharp.Models;

namespace sql_crud_operations_with_csharp.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            using var command = new SqlCommand(sqlQuery, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            { //string FirstName, string LastName, string Country, string PostalCode, string Phone, string Email
                List<string> optionalValues = new List<string>();
                string country = null;
                string phone = null;
                string postalCode = null;
                if (!reader.IsDBNull(3))
                {
                    country = reader.GetString(3);
                }
                if (!reader.IsDBNull(4))
                {
                    postalCode = reader.GetString(4);
                }
                if (!reader.IsDBNull(5))
                {
                    phone = reader.GetString(5);
                }
                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    country,
                    postalCode,
                    phone,
                    reader.GetString(6)
               );
            }
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
