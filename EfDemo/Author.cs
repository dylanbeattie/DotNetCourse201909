using System.Collections.Generic;

namespace EfDemo {
    public class Author {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}

            // foreach(var person in new[] { "yvonne", "jenny", "darren", "toby", "fahim" }) {
            // var sqlConnection = new SqlConnection($"Server=dylan-dotnet-workshop.database.windows.net;Database={person};User Id=workshop;Password=EntityFramework123!;");
            // sqlConnection.Open();
            // sqlConnection.Close();
            // Console.WriteLine(person);
            // Console.WriteLine("It worked!");
            // }

