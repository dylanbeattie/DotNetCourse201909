using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo {
    class Program {
        static void Main(string[] args) {
            const int HOW_MANY_JOKES = 20;
            BackgroundWorker bw = new BackgroundWorker();
            var sw = new Stopwatch();
            sw.Start();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 16 };
            Parallel.For(0, HOW_MANY_JOKES, _ => {
                RandomSleep();
                Console.Write("P ");
            });
            sw.Stop();
            Console.WriteLine($"Parallel: we got {HOW_MANY_JOKES} jokes. It took {sw.ElapsedMilliseconds}ms");
            sw.Reset();
            sw.Start();
            for(var i = 0; i < HOW_MANY_JOKES; i++) {
                RandomSleep();
                Console.Write("S ");
            }
            sw.Stop();
            Console.WriteLine($"Serial: we got {HOW_MANY_JOKES} jokes. It took {sw.ElapsedMilliseconds}ms");
        }



        public static string RandomSleep() {
            var random = new Random();
            Thread.Sleep(random.Next(2000));
            return("OK");
            // const string URL = "http://slowwly.robertomurray.co.uk/delay/500/url/https://icanhazdadjoke.com/";
            // var wc = new WebClient();
            // wc.Headers.Add("Accept", "application/json");
            // return wc.DownloadString(URL);
        }
    }
}
