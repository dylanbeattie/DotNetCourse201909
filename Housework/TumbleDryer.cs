using System;

namespace Housework {
    public class TumbleDryer {
        private readonly HouseworkSimulator sim;

        public TumbleDryer(HouseworkSimulator sim) {
            this.sim = sim;
        }

        public void Dry(Laundry laundry) {
            if (laundry.State != LaundryState.Wet) {
                throw (new Exception("FOR BEST RESULTS ENSURE LAUNDRY IS WET BEFORE ATTEMPTING TO DRY IT."));
            }
            sim.DoWork(TimeSpan.FromHours(3));
            laundry.State = LaundryState.Dry;
            sim.Report("(tumble dryer has finished)");
        }
    }
}