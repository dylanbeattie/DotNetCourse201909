using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdventureWorksDemo {
    class Program {
        const string CONNECTION_STRING = "Server=dylan-dotnet-workshop.database.windows.net;Database=workshop-db-demo;User Id=dylan;Password=;";
        static void Main(string[] args) {
            List<Customer> customers = new List<Customer>();
            var sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();
            var sqlCommand = new SqlCommand("SELECT * FROM SalesLT.Customer", sqlConnection);
            using (var reader = sqlCommand.ExecuteReader()) {
                while (reader.Read()) {
                    try {
                        var customer = new Customer {
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName"))
                        };
                        customers.Add(customer);
                    } catch (Exception ex) {
                        Console.WriteLine(ex);
                    }
                }
            }
            sqlConnection.Close();
            foreach (var customer in customers) {
                Console.WriteLine($"{customer.Title} {customer.LastName}");
            }
            Console.WriteLine("it worked!");
        }
    }

    public class Customer {
        public int CustomerID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}

