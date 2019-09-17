using System;

namespace Interfaces {

    class Program {
        static void Main(string[] args) {
            var dobbin = new Horse();
            var lionel = new Cat();

            var pancakeHouse = new Restaurant();

            pancakeHouse.AddDiner(dobbin);
            pancakeHouse.AddDiner(lionel);
            pancakeHouse.ServeDinner();

            var tourGroup = new TourGroup();
            tourGroup.AddTransport(dobbin);

            var zep = new Zeppelin();
            tourGroup.AddTransport(zep);

            tourGroup.OffWeGo();
            
        }
    }


    public class Cat : IEatFood {
        public string FavouriteFood => "Kibbles";

        public void Eat(string food) {
            Console.WriteLine($"Mmm... {food}. Meow.");
        }
    }

    public class Zeppelin : ICanCarryPassengers {
        public int Passengers => 120;

        public void Transport() {
            Console.WriteLine("Weeeeeeee! Zeppelin ride!");
        }
    }


}
