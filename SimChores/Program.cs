using System;
using System.Threading.Tasks;

namespace Housework {

    internal class Program {
        private static readonly HouseworkSimulator sim = new HouseworkSimulator();
        private static readonly WashingMachine washer = new WashingMachine(sim);
        private static readonly TumbleDryer dryer = new TumbleDryer(sim);

        private static void Main(string[] args) {
            Console.WriteLine("*** Welcome to Housework Simulator! ***");
            CleanAllTheThings().Wait();
            sim.Log("The housework took {0} hrs {1} mins today. Yay.", sim.ElapsedTime.Hours, sim.ElapsedTime.Minutes);
            Relax();
        }

        private static async Task CleanAllTheThings() {
            var laundry = new Laundry() { State = LaundryState.Dirty };
            var wash = RunWashingMachine(laundry);
            CleanBathroom();
            CheckLaundry(wash);
            CleanLivingRoom();
            CheckLaundry(wash);
            CleanKitchen();
            await CheckLaundry(wash);
        }

        private static Task<Laundry> CheckLaundry(Task<Laundry> task) {
             sim.Log("Checking laundry...");
             if(task.IsCompleted) {
                 sim.Log("Laundry is clean!");
                 return RunDryer(task.Result);
             } else {
                 sim.Log("Nope - laundry isn't ready yet...");
                 return task;
             }
        }

        private static void Relax() {
            sim.Log("Commencing relaxation process.");
            sim.Log("(press a key when you feel sufficiently relaxed)");
            Console.ReadKey();
        }

        private static async Task<Laundry> RunWashingMachine(Laundry laundry) {
            return await Task.Run(() => {
                sim.Log("Washing machine is running.");
                washer.Wash(laundry);
                return laundry;
            });
        }

        private static async Task<Laundry> RunDryer(Laundry laundry) {
            return await Task.Run(() => {
                sim.Log("Tumble dryer is running.");
                dryer.Dry(laundry);
                return (laundry);
            });
        }

        private static void PutAwayDryClothes(Laundry laundry) {
            laundry.State = LaundryState.PutAway;
            sim.Log("Dry clothes have been put away.");
        }

        private static void CleanKitchen() {
            sim.Log("Starting to clean kitchen");
            sim.DoWork(TimeSpan.FromHours(1.5));
            sim.Log("Kitchen is now clean");
        }

        private static void CleanBathroom() {
            sim.Log("Starting to clean bathroom");
            sim.DoWork(TimeSpan.FromHours(1));
            sim.Log("Bathroom is now clean");
        }

        private static void CleanLivingRoom() {
            sim.Log("Starting to clean bedroom");
            sim.DoWork(TimeSpan.FromHours(1));
            sim.Log("Bedroom is now clean");
        }
    }
}