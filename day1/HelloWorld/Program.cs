using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(String[] args)
         {
             Console.WriteLine("Hello! Please enter your name:");
             var name = Console.ReadLine();
             if (String.IsNullOrWhiteSpace(name)) {
                 name = "Guest";
             }
             var greeting = $"Hello, {name}";
             Console.WriteLine(greeting);
         }

    }
}
