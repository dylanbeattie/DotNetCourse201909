namespace HonestCars.Model {
    public class CarModel {
        public Manufacturer Make { get; set; }
        public string Name { get; set; }

        public override string ToString() {
            return $"{Make} {Name}";
        }
    }
}

