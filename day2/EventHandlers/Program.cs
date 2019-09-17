using System;

namespace EventHandlers {
    class Program {
        static void Main(string[] args) {
            var randomHouse = new Publisher();

            var harryPotterFan = new BookFan { Name = "Harry", FavouriteBookSubject = "Harry Potter" };
            var dotnetFan = new BookFan { Name = "Dylan", FavouriteBookSubject = ".NET Framework" };

            randomHouse.NewBookIsOut += harryPotterFan.ReactToNewBook;
            randomHouse.NewBookIsOut += dotnetFan.ReactToNewBook;

            randomHouse.Publish("Harry Potter and the .NET Framework");
            randomHouse.Publish("Harry Potter and the Sorcerer's Stone");
            randomHouse.Publish("Advanced .NET Framework 4.8");
            randomHouse.Publish("Scottish Tax Law 2018-2020");
        }

        public static void GetExcitedAboutNewBook(object sender, NewBookEventArgs e) {
            Console.WriteLine($"HEY! {e.Title} IS OUT! WOW!");
        }
    }

    public class BookFan {

        public string Name { get; set; }

        public string FavouriteBookSubject { get; set; }

        public void ReactToNewBook(object sender, NewBookEventArgs e) {
            if (e.Title.Contains(FavouriteBookSubject)) {
                Console.WriteLine($"{Name} is really excited about {e.Title}!");
            }
        }
    }

    public class NewBookEventArgs : EventArgs {
        public string Title { get;set;}
    }

    public class Publisher {
        public event EventHandler<NewBookEventArgs> NewBookIsOut;

        public void Publish(string title) {
            if (this.NewBookIsOut != null) {
                this.NewBookIsOut(this, new NewBookEventArgs { Title = title });
            }
        }
    }
}
