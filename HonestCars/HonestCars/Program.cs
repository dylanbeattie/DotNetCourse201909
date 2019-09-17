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
            var astra = vauxhall.LaunchNewModel("Astra", 14000M);
            var corsa = vauxhall.LaunchNewModel("Corsa", 11000M);

            vehicles.Add(vauxhall.CreateCar(astra, "123ABC", 2006));
            vehicles.Add(vauxhall.CreateCar(corsa, "456DEF", 2008));

            var mini = new Manufacturer { Name = "Mini" };
            var cooper = mini.LaunchNewModel("Cooper", 9000M);
            vehicles.Add(mini.CreateCar(cooper, "789XYZ", 1984));

            var vw = new Manufacturer { Name = "Volkswagen" };
            var beetle = mini.LaunchNewModel("Beetle", 6500M);
            vehicles.Add(vw.CreateCar(beetle, "AB4567", 1957));
        }
    }
}


