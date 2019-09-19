namespace HonestCars.DataModel {
    public class CarModel {

        public int CarModelID { get; set; }

        public Manufacturer Make { get; set; }

        public string Name { get; set; }
        
        public decimal ListPrice { get; internal set; }

        public override string ToString() {
            return $"{Make} {Name}";
        }
    }
}

