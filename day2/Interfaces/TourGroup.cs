using System.Collections.Generic;

namespace Interfaces {
    class TourGroup {
        List<ICanCarryPassengers> transports = new List<ICanCarryPassengers>();
        public void AddTransport(ICanCarryPassengers transport) {
            this.transports.Add(transport);
        }
        public void OffWeGo() {
            foreach(var t in transports) {
                t.Transport();
            }
        }
        

    }
}
