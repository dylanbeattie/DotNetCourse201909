using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EfDemo {
    class Program {
        static void Main(string[] args) {
            using (var myDbContext = new MyDbContext()) {
                myDbContext.Database.Migrate();

                var jkRowling = myDbContext.Authors.First(a => a.Name == "JK Rowling");
                var book1 = new Book { Title = "Harry Potter and the ISBN Number", Author = jkRowling, IsbnNumber = "978-3-16-148410-0" };
                myDbContext.Books.Add(book1);
                var book2 = new Book { Title = "Harry Potter and the Database Migrations", Author = jkRowling, IsbnNumber = "978-3-16-148555-0" };

                myDbContext.Books.Add(book2);
                myDbContext.SaveChanges();

                var booksToDelete = myDbContext.Books
                    .Where(book => book.ListPrice == 0.0M);

                foreach (var book in booksToDelete) {
                    myDbContext.Books.Remove(book);
                }

                var authorsToDelete = myDbContext.Authors.Where(
                    author => ! author.Books.Any()
                );
                foreach(var author in authorsToDelete) {
                    myDbContext.Authors.Remove(author);
                }
                myDbContext.SaveChanges();

                var howManyBooks = myDbContext.Books.Count();
                var howManyAuthors = myDbContext.Authors.Count();

                Console.WriteLine($"You have {howManyBooks} books and {howManyAuthors} authors.");
            }
        }
    }

    public class MyDbContext : DbContext {


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

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(GetLoggerFactory())
                .UseSqlServer(CONNECTION_STRING);
        }
    }
}

// foreach(var person in new[] { "yvonne", "jenny", "darren", "toby", "fahim" }) {
// var sqlConnection = new SqlConnection($"Server=dylan-dotnet-workshop.database.windows.net;Database={person};User Id=workshop;Password=EntityFramework123!;");
// sqlConnection.Open();
// sqlConnection.Close();
// Console.WriteLine(person);
// Console.WriteLine("It worked!");
// }

