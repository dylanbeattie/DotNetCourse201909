using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HonestCars.WebApplication.Models;
using HonestCars.DataModel;
using Microsoft.EntityFrameworkCore;

namespace HonestCars.WebApplication.Controllers {
    public class ManufacturersController : Controller {
        private HonestCarsDbContext dbContext;

        public ManufacturersController(HonestCarsDbContext dbContext) {
            this.dbContext = dbContext;
        } 

        // [HttpPost]
        // public async Task<IActionResult> NewModel(
        //     [Bind("ManufacturerID,Name,ListPrice")] 
        //     NewCarModelViewModel model
        // ) {
        //     if (ModelState.IsValid) {
        //         var manufacturer = await dbContext.Manufacturers.FindAsync(model.ManufacturerID);
        //         if (manufacturer == null) return NotFound();
        //         var carModel = manufacturer.LaunchNewModel(model.Name, model.ListPrice);
        //         dbContext.CarModels.Add(carModel);
        //         await dbContext.SaveChangesAsync();
        //         return RedirectToAction(nameof(Detail), new { id = model.ManufacturerID });
        //     } else {
        //         return await Detail(model.ManufacturerID);
        //     }
        // }

        // public async Task<IActionResult> Detail(int id) {
        //   var mfr = await dbContext.Manufacturers.FindAsync(id);

        //   var model = new NewCarModelViewModel {
        //       ManufacturerID = mfr.ManufacturerID,
        //       Manufacturer = mfr,
        //   };
        //   return View(model);
        // }

        public async Task<IActionResult> Index() {
            var manufacturers = await dbContext.Manufacturers.OrderBy(m => m.Name).ToListAsync();
            return View(manufacturers);
        }

        public IActionResult Create() {
            return (View());
        }

        [HttpPost]
        public IActionResult Create([Bind("Name")] Manufacturer manufacturer) {
            if (ModelState.IsValid) {
                dbContext.Manufacturers.Add(manufacturer);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            } else {
              ViewBag.TheThingThatWentWrong = "That model is not valid!";
              return(View(manufacturer));           
            }
        }
    }
}