using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace AdventureWorksDemo {
    class Program {
        const string CONNECTION_STRING = "Server=dylan-dotnet-workshop.database.windows.net;Database=workshop-db-demo;User Id=dylan;Password=MaximumSecurity123!;";
        static void Main(string[] args) {
            var sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();

            var customerID = 42;

            var customer = sqlConnection.QuerySingle<Customer>(
                "SELECT * FROM SalesLT.Customer WHERE CustomerID = @CustomerID",
                new { CustomerID = customerID }
            );

            customer.FirstName = "Jonathan";
            customer.LastName = "Satchel";
            sqlConnection.Execute(@"
                UPDATE SalesLT.Customer 
                SET FirstName = @FirstName, LastName = @LastName
                WHERE CustomerID = @CustomerID",
                customer);
            sqlConnection.Close();

            // var customers = sqlConnection.Query<Customer>(
            //     "SELECT * FROM SalesLT.Customer WHERE LastName LIKE '%' + @LastName + '%'",
            //     new { LastName = "bea" }
            // );
            // foreach (var customer in customers) {
            //     Console.WriteLine(customer);
            // }
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

        public override string ToString() {
            return $"CustomerID: {CustomerID} : {Title} {FirstName} {MiddleName} {LastName} ({CompanyName}";
        }

    }
}

