using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Please enter a value for fizz:");
                var fizz = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please enter a value for buzz:");
                var buzz = Int32.Parse(Console.ReadLine());
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
            } catch(FormatException ex) {
                DisplayErrorMessage("Sorry - I don't know how to translate that into a number", ex);
            } catch(OverflowException ex) {
                DisplayErrorMessage("Sorry - I can't cope with numbers that big!", ex);
            } catch (Exception ex) {
                DisplayErrorMessage("Something unexpected happened!", ex);
            }
        }

        static void DisplayErrorMessage(string message, Exception ex) {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ex);
        }
    }
}

