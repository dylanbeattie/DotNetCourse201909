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

    public T Create<T>(CarModel model, 
      string partialChassisNumber,
      int year,
      Condition condition
    ) where T : Vehicle, new() {
      var fullChassisNumber = this.ChassisNumberPrefix + partialChassisNumber;
      return new T() {
        Year = year,
        Model = model,
        ChassisNumber = fullChassisNumber,
        Condition = condition,
      };
    }

    public override string ToString() {
      return Name;
    } 
  }
}
        
