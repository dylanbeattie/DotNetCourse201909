using System;
using System.Collections.Generic;

namespace HonestCars.Model {
  public class Person {
    public string Name { get; set; }
    
    private decimal BankBalance { get; set; }
    
    public List<Vehicle> Cars { get; } = new List<Vehicle>();

    public Person(string name) {
      this.BankBalance = 1_000_000M;
      this.Name = name;
    }

    public void ReceiveCar(Vehicle car) {
      car.Owner = this;
      Cars.Add(car);
    }

    public void TransferCar(Person buyer, Vehicle car) {
      this.Cars.Remove(car);
      buyer.Cars.Add(car);
    }

    public void BuyCar(Person seller, Vehicle car) {
      if (seller.Cars.Contains(car)) {
        this.WithdrawFunds(car.Price);
        seller.DepositFunds(car.Price);
        car.TransferToNewOwner(this);
      } else {
        Console.WriteLine("DANGER! The seller doesn't actually own that car!");
      }
    }

    private void WithdrawFunds(decimal amount) {
      this.BankBalance -= amount;
    }

    public void DepositFunds(decimal amount) {
      this.BankBalance += amount;
    }

    public override string ToString() {
      var result = $"{Name} (Balance: {BankBalance:C})";
      if (Cars.Count > 0) {
      foreach(var car in Cars) {
        result += Environment.NewLine + "* " + car.ToString();
      }
      } else {
        result += " (no cars!)";
      }
      return(result);
    }
  }
}
        
