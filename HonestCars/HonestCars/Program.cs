using System;
using HonestCars.Model;

namespace HonestCars {
    class Program
    {
        static void Main(string[] args)
        {
            var vauxhall = new Manufacturer { Name = "Vauxhall" };
            var astra = vauxhall.LaunchNewModel("Astra");
            var astra1400 = vauxhall.CreateVariant(astra, 1400);
            var astra1600 = vauxhall.CreateVariant(astra, 1600);

            var car1 = vauxhall.CreateCar(astra1400, "123ABC");
            var car2 = vauxhall.CreateCar(astra1600, "456DEF");

            Console.WriteLine(car1);
            Console.WriteLine(car2);
        }
    }
}


