using System.ComponentModel.DataAnnotations;

namespace EfDemo {
    public class Book {
        [Required]
        public Author Author { get; set; }
        public int BookID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public decimal ListPrice { get; set; } = 25.0M;

        [Required]
        [StringLength(32)]
        public string IsbnNumber { get; set; }
    }
}

            // foreach(var person in new[] { "yvonne", "jenny", "darren", "toby", "fahim" }) {
            // var sqlConnection = new SqlConnection($"Server=dylan-dotnet-workshop.database.windows.net;Database={person};User Id=workshop;Password=EntityFramework123!;");
            // sqlConnection.Open();
            // sqlConnection.Close();
            // Console.WriteLine(person);
            // Console.WriteLine("It worked!");
            // }

