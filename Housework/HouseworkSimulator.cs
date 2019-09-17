using System;
using System.Threading;

namespace Housework {
    public class HouseworkSimulator {

        public void Report(string message, params object[] args) {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Log(message, args);
            Console.ForegroundColor = c;
        }
        public void Log(string message, params object[] args) {
            Console.WriteLine("{0} [Thread #{1}] {2}", TimeOfDay.ToString("hh:mm:tt"), Thread.CurrentThread.ManagedThreadId, String.Format(message, args));
            Thread.Sleep(200);
        }

        public readonly int TimeSpeedup = (int)(TimeSpan.FromHours(1).Ticks / TimeSpan.FromSeconds(2.5).Ticks);
        private readonly DateTime simRunStartedAt = DateTime.Now;
        private readonly DateTime houseworkStartedAt = DateTime.Today.Date.AddHours(9);

        public TimeSpan ElapsedTime {
            get {
                return (TimeOfDay - houseworkStartedAt);
            }
        }

        public DateTime TimeOfDay {
            get {
                var elapsed = DateTime.Now - simRunStartedAt;
                return (houseworkStartedAt.AddSeconds(elapsed.TotalSeconds * TimeSpeedup));
            }
        }


        public void DoWork(TimeSpan span, string message = null) {
            var actualTime = (int)(span.TotalMilliseconds / TimeSpeedup);
            Thread.Sleep(actualTime);
            if (!String.IsNullOrEmpty(message)) Log(message);
        }
    }
}