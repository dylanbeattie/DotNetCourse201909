using System;

namespace Switches
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name:");
            var name = Console.ReadLine();
            switch(name) {
                case "Elizabeth II":
                    Console.WriteLine("Hello, Your Majesty");
                    break;
                case "":
                    Console.WriteLine("Hello, Guest");
                    break;
                default: 
                    Console.WriteLine($"Hello, {name}");
                    break;
            }
        }
    }
}
