using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using HonestCars.Model;

namespace HonestCars {
    class Program {
        static void Main(string[] args) {
            List<Vehicle> vehicles = new List<Vehicle>();
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

        static void PopulateCarData(List<Vehicle> vehicles) {

            var vauxhall = new Manufacturer { Name = "Vauxhall" };
            var astra = vauxhall.LaunchNewModel("Astra", 14000M);
            var corsa = vauxhall.LaunchNewModel("Corsa", 11000M);
            
            vehicles.Add(vauxhall.Create<DieselCar>(astra, "123ABC", 2006, Condition.Good));
            vehicles.Add(vauxhall.Create<PetrolCar>(corsa, "456DEF", 2008, Condition.Good).WithEngineSize(1200));

            var mini = new Manufacturer { Name = "Mini" };
            var cooper = mini.LaunchNewModel("Cooper", 9000M);
            vehicles.Add(mini.Create<PetrolCar>(cooper, "789XYZ", 1984, Condition.Good));

            var vw = new Manufacturer { Name = "Volkswagen" };
            var beetle = mini.LaunchNewModel("Beetle", 6500M);
            vehicles.Add(vw.Create<PetrolCar>(beetle, "AB4567", 1957, Condition.Good).WithEngineSize(800));
        }
    }
}


