namespace HonestCars.Model {

  public class Manufacturer {
  
    private string ChassisNumberPrefix {
      get {
        return this.Name.Substring(0,4).ToUpper();
      }
    }

    public string Name { get; set; }

    public CarModel LaunchNewModel(string name, decimal listPrice) {
      var model = new CarModel();
      model.ListPrice = listPrice;
      model.Make = this;
      model.Name = name;
      return model;
    }

    public Car CreateCar(CarModel model, 
      string partialChassisNumber,
      int year
    ) {
      var fullChassisNumber = this.ChassisNumberPrefix + partialChassisNumber;
      return new Car {
        Year = year,
        Model = model,
        ChassisNumber = fullChassisNumber
      };
    }

    public override string ToString() {
      return Name;
    } 
  }
}
        
