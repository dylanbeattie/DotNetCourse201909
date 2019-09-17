using System;

namespace DivideByZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = 1.0f;
            var y = 0.0f;
            var z = x / y;
            for(var i = 0; i < z; i++) {
                Console.WriteLine("To infinity... and BEYOND!");
            }
            Console.WriteLine(z);
            Console.WriteLine("Hello World!");
        }
    }
}
