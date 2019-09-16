using System;

namespace HonestCars {
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Car();
            c.Price = 123.45M;
            c.Price = 45678.9M;
            Console.WriteLine(c.Price);
        }
    }
}
