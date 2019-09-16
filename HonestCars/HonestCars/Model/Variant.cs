namespace HonestCars.Model {
    public class Variant {
        public CarModel Model { get; set; }
        public int EngineSize { get; set; }

        public override string ToString() {
            return $"{Model}, {EngineSize} cc";
        }
    }
}

