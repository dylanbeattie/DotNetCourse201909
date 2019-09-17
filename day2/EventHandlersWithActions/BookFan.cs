using System;

namespace EventHandlers {
    public class BookFan {

        public void FollowPublisher(Publisher p) {
            p.NewBookIsOut += this.ReactToNewBook;
        }

        public void UnfollowPublisher(Publisher p) {
            p.NewBookIsOut -= this.ReactToNewBook;
        }

        public string Name { get; set; }

        public string FavouriteBookSubject { get; set; }

        public void ReactToNewBook(string title) {
            if (title.Contains(FavouriteBookSubject)) {
                Console.WriteLine($"{Name} is really excited about {title}!");
            }
        }
    }
}
