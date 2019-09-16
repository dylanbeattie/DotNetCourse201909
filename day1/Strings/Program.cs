using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var multilineString = @"This

THIS
is a string
with lots of lines in it!";
            Console.WriteLine(multilineString);
        }
    }
}
