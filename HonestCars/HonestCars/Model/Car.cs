using System;

namespace HonestCars.Model {
    public class Car {
        const decimal POST_SALE_PRICE_MULTIPLIER = 0.8M;

        public int Year {  get; set; }
        public Variant Variant { get; set; }
        public string ChassisNumber { get; set; }

        public override string ToString() {
            return $"{ChassisNumber} ({Variant} / {Year})";
        }

        public decimal Price {
            get {
                var price = this.Variant.ListPrice * POST_SALE_PRICE_MULTIPLIER;
                var currentYear = DateTime.Now.Year;
                var age = currentYear - Year;
                for(var i = 0; i < age; i++) price = price * 0.9M;
                return price;
            }
        }
    }
}