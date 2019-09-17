using System;

namespace Enumerations {
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pizza {
                Size = PizzaSize.Large,
                Toppings = PizzaToppings.Olives
                    | PizzaToppings.Tomato
                    // | PizzaToppings.Ham
            };
            Console.WriteLine(p);
            Console.WriteLine(p.IsVegan);
            Console.WriteLine(p.IsVegetarian);
        }
    }
}
