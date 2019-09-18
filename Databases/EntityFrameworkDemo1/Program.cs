using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EntityFrameworkDemo1 {

    
    class Program {



        static void Main(string[] args) {
            using(var dbContext = new BooksDbContext()) {
                dbContext.Database.EnsureCreated();

                var booksWithReallyShortTitles = dbContext.Books
                .Where(book => book.Title.Length > 10)
                .OrderBy(book => book.Title.Length);

                foreach(var book in booksWithReallyShortTitles) {
                    Console.WriteLine(book.Title);
                }

                // foreach(var book in dbContext.Books) {
                //     Console.WriteLine(book);
                // }
            }
        }

        public void CreateSomeBooks(BooksDbContext dbContext) {
            var stephenKing = new Author { Name = "Stephen King" };
            stephenKing.WriteBook("It");
            stephenKing.WriteBook("Carrie");
            stephenKing.WriteBook("Christine");

            dbContext.Authors.Add(stephenKing);
            dbContext.SaveChanges();
        }
    }

    public class BooksDbContext : DbContext {

        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((_, __) => true, true)
        });
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        const string CONNECTION_STRING = "Server=dylan-dotnet-workshop.database.windows.net;Database=ef-demo;User Id=dylan;Password=;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            base.OnConfiguring(builder);
            builder
                .UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
                .EnableSensitiveDataLogging()  
                .UseSqlServer(CONNECTION_STRING);
        } 
    }

    public class Author {
        public int AuthorID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public Book WriteBook(string title) {
            var book = new Book { Title = title, Author = this };
            this.Books.Add(book);
            return(book);
        }
    }

    public class Book {
        public Author Author { get; set; }
        public int BookID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Publisher { get; set; }
    }
}
