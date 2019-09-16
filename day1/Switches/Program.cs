using System;

namespace Switches
{
    class Program
    {
        static void Main(string[] args)
        {
            const string empty_string = String.Empty;
            Console.WriteLine("Please enter your name:");
            var name = Console.ReadLine();
            switch(name) {
                case "Louis XIV":
                case "King Kong":
                case "Elizabeth II":
                    Console.WriteLine("Hello, Your Majesty");
                    break;
                case empty_string:
                    Console.WriteLine("Hello, Guest");
                    break;
                default: 
                    Console.WriteLine($"Hello, {name}");
                    break;
            }
        }
    }
}
