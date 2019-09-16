namespace HonestCars.Model {
    public class Variant {
        public CarModel Model { get; set; }
        public int EngineSize { get; set; }
        public decimal ListPrice { get; internal set; }

        public override string ToString() {
            return $"{Model}, {EngineSize} cc";
        }
    }
}

