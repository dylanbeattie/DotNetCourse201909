using HonestCars.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace HonestCars.WebApplication.Models {
    public class NewCarModelViewModel {
        [HiddenInput]
        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }
    }
}