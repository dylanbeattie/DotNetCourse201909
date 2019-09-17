using System;

namespace HonestCars.Model {
    public class Car {
        public Person Owner { get; set; }

        const decimal POST_SALE_PRICE_MULTIPLIER = 0.8M;

        public int Year {  get; set; }
        public CarModel Model { get; set; }
        public string ChassisNumber { get; set; }

        public Condition Condition { get; set; }

        public void TransferToNewOwner(Person newOwner) {
            this.Owner.Cars.Remove(this);
            newOwner.ReceiveCar(this);
            this.Owner = newOwner;
        }

        public override string ToString() {
            return $"{ChassisNumber} ({Model} / {Year})";
        }

        public decimal Price {
            get {
                var price = this.Model.ListPrice * POST_SALE_PRICE_MULTIPLIER;
                var currentYear = DateTime.Now.Year;
                var age = currentYear - Year;
                for(var i = 0; i < age; i++) price = price * 0.9M;
                return price;
            }
        }
    }
}