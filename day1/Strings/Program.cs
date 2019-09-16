using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            var s = "Hello";
            s = s.Replace('e', 'a');
            Console.WriteLine(s);

            // var s = "";
            // var sb = new System.Text.StringBuilder();
            // for(var i = 0; i <100; i++) {
            //     sb.Append("hello ");
            // }
            // s = sb.ToString();
            // Console.WriteLine(s);
            // Console.WriteLine(s.Length);
            // for(var i = 0; i < s.Length; i++) {
            //     Console.WriteLine(Convert.ToString(s[i], 2));
            // }   
        }
    }
}
