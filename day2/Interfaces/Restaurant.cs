using System.Collections.Generic;

namespace Interfaces {
    class Restaurant {
        List<IEatFood> diners = new List<IEatFood>();
        public void AddDiner(IEatFood diner) {
            this.diners.Add(diner);
        }
        public void ServeDinner() {
            foreach(var diner in diners) {
                diner.Eat("Pancakes");
            }
        }
    }
}
