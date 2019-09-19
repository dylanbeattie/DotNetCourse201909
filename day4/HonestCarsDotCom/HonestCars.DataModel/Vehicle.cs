using System;
using System.ComponentModel.DataAnnotations;

namespace HonestCars.DataModel {
    public class Vehicle {

        [Key]
        public string ChassisNumber { get; set; }

        public Person Owner { get; set; }

        const decimal POST_SALE_PRICE_MULTIPLIER = 0.8M;

        public int Year { get; set; }
        public CarModel Model { get; set; }

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
                switch (this.Condition) {
                    case Condition.WriteOff: price = price * 0.1M; break;
                    case Condition.Fair: price = price * 0.4M; break;
                }
                var currentYear = DateTime.Now.Year;
                var age = currentYear - Year;
                for (var i = 0; i < age; i++) price = price * 0.9M;
                return price;
            }
        }
    }
}

