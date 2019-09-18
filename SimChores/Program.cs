using System;
using System.Threading.Tasks;

namespace Housework {

    internal class Program {
        private static readonly HouseworkSimulator sim = new HouseworkSimulator();
        private static readonly WashingMachine washer = new WashingMachine(sim);
        private static readonly TumbleDryer dryer = new TumbleDryer(sim);

        private static void Main(string[] args) {
            Console.WriteLine("*** Welcome to Housework Simulator! ***");
            CleanAllTheThings();
            sim.Log("The housework took {0} hrs {1} mins today. Yay.", sim.ElapsedTime.Hours, sim.ElapsedTime.Minutes);
            Relax();
        }

        private static void CleanAllTheThings() {
            var laundry = new Laundry() { State = LaundryState.Dirty };
            RunWashingMachine(laundry);
            RunDryer(laundry);
            CleanBathroom();
            PutAwayDryClothes(laundry);
            CleanLivingRoom();
            CleanKitchen();
            PutAwayDryClothes(laundry);
        }

        private static void Relax() {
            sim.Log("Commencing relaxation process.");
            sim.Log("(press a key when you feel sufficiently relaxed)");
            Console.ReadKey();
        }

        private static Laundry RunWashingMachine(Laundry laundry) {
            sim.Log("Washing machine is running.");
            washer.Wash(laundry);
            return laundry;
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