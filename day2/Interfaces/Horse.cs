using System;

namespace Interfaces {
    public class Horse : ICanCarryPassengers, IEatFood {
        public int Passengers => 2;

        public string FavouriteFood => "Pancakes";

        public void Eat(string food) {
            if (food == FavouriteFood) {
                Console.WriteLine("Enthusiastic munching commences!");
            } else {
                Console.WriteLine("Lacklusture eating in progress.");
            }
        }

        public void Transport() {
            Console.WriteLine($"Carrying passengers! clip clop.");
        }
    }
}
