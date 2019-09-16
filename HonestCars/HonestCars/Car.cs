using System;

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

    public Variant CreateVariant(CarModel model, int engineSize) {
      return new Variant {
        Model = model,
        EngineSize = engineSize,
      };      
    }

    public Car CreateCar(Variant variant, string partialChassisNumber) {
      var fullChassisNumber = this.ChassisNumberPrefix + partialChassisNumber;
      return new Car {
        Variant = variant,
        ChassisNumber = fullChassisNumber
      };
    }

    public override string ToString() {
      return Name;
    } 
  }

  public class CarModel {
    public Manufacturer Make { get; set;}
    public string Name { get; set; }
    
    public override string ToString() {
      return $"{Make} {Name}";
    }
  }

  public class Variant {
    public CarModel Model { get; set; }
    public int EngineSize  { get; set; }

    public override string ToString() {
      return $"{Model}, {EngineSize} cc";
    }
  }

  public class Car {
    public Variant Variant { get; set; }
    public string ChassisNumber { get; set; }

    public override string ToString() {
      return $"{ChassisNumber} ({Variant})";
    }
  }

  // public class Car {
  //     public string Make { get; }
  //     public string Model { get; }      

  //     public decimal Price { get; set; }
  //     public int Mileage { get; set; }
  //     public string Color { get; set; }
  //     public int Year { get; set; }

  //     public override string ToString() {
  //       return $"{Make} {Model} ({Year}, {Mileage} miles) {Price:C}";
  //     }

  //     public Car(string make, string model) {
  //       this.Make = make;
  //       this.Model = model;
  //     }

  //     public Car(string make, string model, string color, int year, 
  //       int mileage, decimal price) {
  //       this.Make = make;
  //       this.Model = model;
  //       this.Color = color;
  //       this.Year = year;
  //       this.Mileage = mileage;
  //       this.Price = price;
  //     }
  //   }
}
        
