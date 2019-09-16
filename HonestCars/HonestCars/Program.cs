using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using HonestCars.Model;

namespace HonestCars {
    class Program {
        static void Main(string[] args) {
            List<Car> vehicles = new List<Car>();
            PopulateCarData(vehicles);

            var astra1400 = vehicles[0];

            Person alice = new Person("Alice");
            Person bob = new Person("Bob");

            alice.ReceiveCar(astra1400);

            Console.WriteLine(alice);
            Console.WriteLine(bob);
            Console.WriteLine("================================");

            bob.BuyCar(alice, astra1400);

            Console.WriteLine(alice);
            Console.WriteLine(bob);
            Console.WriteLine("================================");
        }

        static void PopulateCarData(List<Car> vehicles) {
            var vauxhall = new Manufacturer { Name = "Vauxhall" };
            var astra = vauxhall.LaunchNewModel("Astra");
            var astra1400 = vauxhall.CreateVariant(astra, 1400, 14000M);
            var astra1600 = vauxhall.CreateVariant(astra, 1600, 17000M);

            vehicles.Add(vauxhall.CreateCar(astra1400, "123ABC", 2006));
            vehicles.Add(vauxhall.CreateCar(astra1600, "456DEF", 2008));

            var mini = new Manufacturer { Name = "Mini" };
            var cooper = mini.LaunchNewModel("Cooper");
            var mini900  = mini.CreateVariant(cooper, 900, 8000M);
            var mini2600 = mini.CreateVariant(cooper, 2600, 45000M);

            vehicles.Add(mini.CreateCar(mini900, "789XYZ", 1984));
            vehicles.Add(mini.CreateCar(mini2600, "123ABC", 2014));
        }
    }
}


