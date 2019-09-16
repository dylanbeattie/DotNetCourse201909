namespace HonestCars.Model {
    public class Car {
        public Variant Variant { get; set; }
        public string ChassisNumber { get; set; }

        public override string ToString() {
            return $"{ChassisNumber} ({Variant})";
        }
    }
}