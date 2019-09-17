using System;

namespace Housework {
    public class WashingMachine {
        private readonly HouseworkSimulator sim;
        private Random random = new Random();
        public WashingMachine(HouseworkSimulator sim) {
            this.sim = sim;
        }

        public void Wash(Laundry laundry) {
            for (int i = 0; i < 5; i++) {
                if (random.Next(2) == 1) {
                    sim.Report("A mysterious burning smell...");
                    laundry.State = LaundryState.OnFire;
                    throw (new Exception("Washing machine on fire!"));
                }
                sim.DoWork(TimeSpan.FromHours(0.5));

            }
            laundry.State = LaundryState.Wet;
            sim.Report("(washing machine has finished)");
        }
    }
}