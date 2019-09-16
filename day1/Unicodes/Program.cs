using System;

namespace Unicodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "A", "✅", "Привет", "🇬🇧" };
            foreach(var s in strings) {
                Console.WriteLine("========================================");
                Console.WriteLine($"STRING: {s}");
                Console.WriteLine($"s.Length: {s.Length}");
                var bytes = System.Text.Encoding.UTF8.GetBytes(s);
                var chars = System.Text.Encoding.UTF8.GetChars(bytes);
                Console.WriteLine($"Characters: {chars.Length}");
                foreach(var c in chars) {
                    Console.WriteLine("Category: " + Char.GetUnicodeCategory(c));
                }
                Console.WriteLine("Bytes: " + bytes.Length);
                foreach(var b in bytes) {
                    Console.Write(Convert.ToString(b, 2));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
