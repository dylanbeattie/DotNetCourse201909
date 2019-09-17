using System;
using System.Collections.Generic;

namespace Inheritance {
    public class Zoo {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public void AddAnimal(Animal animal) {
            this.Animals.Add(animal);
        }

        public void Tour() {
            foreach(Animal a in Animals) {
                Console.WriteLine($"This is {a.Name}. They say '{a.SayHello()}'");
            }
        }
    }
}
