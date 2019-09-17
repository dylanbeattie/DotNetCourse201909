using System;
using System.Threading.Tasks;

namespace Housework {

    internal class Program {
        private static readonly HouseworkSimulator sim = new HouseworkSimulator();
        private static readonly WashingMachine washer = new WashingMachine(sim);
        private static readonly TumbleDryer dryer = new TumbleDryer(sim);

        private static void Main(string[] args) {
            Console.WriteLine("*** Welcome to Housework Simulator! ***");
            var housework = CleanAllTheThings();
            try {
                housework.Wait();
            } catch (AggregateException aex) {
                Console.WriteLine("You're in trouble now...");
                foreach (var ex in aex.Flatten().InnerExceptions) {
                    Console.WriteLine(ex.Message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            sim.Log("The housework took {0} hrs {1} mins today. Yay.", sim.ElapsedTime.Hours, sim.ElapsedTime.Minutes);
            Relax();
        }

        private static async Task CleanAllTheThings() {
            var laundry = new Laundry() { State = LaundryState.Dirty };
            var washCycle = RunWashingMachine(laundry);
            CleanBathroom();
            CheckLaundry(washCycle);
            CleanLivingRoom();
            CheckLaundry(washCycle);
            CleanKitchen();
            CheckLaundry(washCycle);
            PutAwayDryClothes(laundry);
        }

        private static void CheckLaundry(Task<Laundry> laundry) {
            sim.Log("Checking laundry...");
            if (laundry.IsCompleted) {
                sim.Log("Laundry is clean! Hurrah!");
                RunDryer(laundry.Result);
            } else {
                sim.Log("Nope - laundry still going. What else is there to do?");
            }
        }

        private static void Relax() {
            sim.Log("Commencing relaxation process.");
            sim.Log("(press a key when you feel sufficiently relaxed)");
            Console.ReadKey();
        }

        private static async Task<Laundry> RunWashingMachine(Laundry laundry) {
            return await Task.Run(
                () => {
                    sim.Log("Washing machine is running.");
                    washer.Wash(laundry);
                    return laundry;
                });
        }

        private static Laundry RunDryer(Laundry laundry) {
            sim.Log("Tumble dryer is running.");
            dryer.Dry(laundry);
            return (laundry);
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