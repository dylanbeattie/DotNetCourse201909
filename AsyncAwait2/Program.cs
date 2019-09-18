using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait2
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThings().Wait();
            Console.WriteLine("All tasks are completed!");
        }

        public static async Task DoThings() {
            var tasks = StartRandomTasks(10);            
            Task.WaitAll(tasks.ToArray());
            foreach(var task in tasks) {
                Console.WriteLine(await task);
            }
        }


        public static List<Task<String>> StartRandomTasks(int howMany) {
            List<Task<string>> tasks = new List<Task<string>>();
            var random = new Random();
            for(var i = 0; i < howMany; i++) {
                tasks.Add(RandomDelay(random));
            };
            return tasks;
        }

        public static async Task<string> RandomDelay(Random random) {
            return await Task.Run(() => {
                var delay = random.Next(5000);
                Thread.Sleep(delay);
                // Console.WriteLine($"Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}: I slept for {delay} milliseconds!");
                return($"I slept for {delay} milliseconds!");
            });
        }
    }
}
