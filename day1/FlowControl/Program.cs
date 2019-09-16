using System;

namespace FlowControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "Hello World 😀✅";
            foreach(var c in s) {
                Console.WriteLine(c);
            }
            
            // Console.WriteLine("Hello World!");
        }
    }
}
