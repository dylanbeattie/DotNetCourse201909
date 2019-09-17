using System;

namespace EventHandlers {
    class Program {
        static void Main(string[] args) {

            Publisher sparta = null;

            // When we write this:
            sparta?.Publish("Hello World: The Book");

            // The C# compiler actually generates THIS:
            // if (sparta != null) sparta.Publish("Hello World: The Book");

            var randomHouse = new Publisher();
            var wroxPress = new Publisher();
            var darkHorse = new Publisher();

            var harryPotterFan = new BookFan { Name = "Harry", FavouriteBookSubject = "Harry Potter" };
            var dotnetFan = new BookFan { Name = "Dylan", FavouriteBookSubject = ".NET Framework" };

            wroxPress.Publish("Advanced .NET Framework First Edition");
            dotnetFan.FollowPublisher(wroxPress);
            wroxPress.Publish("Advanced .NET Framework Second Edition");
            dotnetFan.UnfollowPublisher(wroxPress);
            wroxPress.Publish("Advanced .NET Framework Third Edition");

            randomHouse.Publish("Harry Potter and the .NET Framework");
            randomHouse.Publish("Harry Potter and the Sorcerer's Stone");
            randomHouse.Publish("Advanced .NET Framework 4.8");
            randomHouse.Publish("Scottish Tax Law 2018-2020");
        }
    }

    public class NewBookEventArgs : EventArgs {
        public string Title { get; set; }
    }

    public class Publisher {
        public event Action<string> NewBookIsOut;

        public void Publish(string title) {
            this.NewBookIsOut?.Invoke(title);
        }
    }
}

