using System;

namespace FlowControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizz = 3;
            var buzz = 5;
            for (var i = 0; i < 100; i++) {
                if(i % fizz == 0 && i % buzz == 0) {
                    Console.WriteLine("FizzBuzz");
                } else if (i % fizz == 0) {
                    Console.WriteLine("Fizz");
                } else if (i % buzz == 0) {
                    Console.WriteLine("Buzz");
                } else {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
