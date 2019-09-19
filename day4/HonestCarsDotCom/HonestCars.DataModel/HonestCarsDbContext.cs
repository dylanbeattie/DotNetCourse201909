using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Diagnostics;


namespace HonestCars.DataModel {
    public class HonestCarsDbContext : DbContext {

        static ILoggerFactory GetLoggerFactory() {
            var consoleLoggerProvider = new ConsoleLoggerProvider((_, __) => true, true);
            return new LoggerFactory(new[] {
                consoleLoggerProvider
            });
        }

        const string CONNECTION_STRING = @"Server=dylan-dotnet-workshop.database.windows.net;
            Database=dylan;
            User Id=workshop;
            Password=EntityFramework123!;";

        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(GetLoggerFactory())
                .UseSqlServer(CONNECTION_STRING);
        }
    }
}