namespace HonestCars.Model {

  public class Manufacturer {
  
    private string ChassisNumberPrefix {
      get {
        return this.Name.Substring(0,4).ToUpper();
      }
    }

    public string Name { get; set; }
    public CarModel LaunchNewModel(string name) {
      var model = new CarModel();
      model.Make = this;
      model.Name = name;
      return model;
    }

    public Variant CreateVariant(CarModel model, int engineSize, decimal listPrice) {
      return new Variant {
        Model = model,
        EngineSize = engineSize,
        ListPrice = listPrice
      };      
    }

    public Car CreateCar(Variant variant, 
      string partialChassisNumber,
      int year
    ) {
      var fullChassisNumber = this.ChassisNumberPrefix + partialChassisNumber;
      return new Car {
        Year = year,
        Variant = variant,
        ChassisNumber = fullChassisNumber
      };
    }

    public override string ToString() {
      return Name;
    } 
  }
}
        
