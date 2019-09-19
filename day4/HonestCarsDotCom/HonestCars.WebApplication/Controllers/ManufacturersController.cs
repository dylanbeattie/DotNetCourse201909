using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HonestCars.WebApplication.Models;
using HonestCars.DataModel;
using Microsoft.EntityFrameworkCore;

namespace HonestCars.WebApplication.Controllers
{
    public class ManufacturersController : Controller {
      private HonestCarsDbContext dbContext;

      public ManufacturersController(HonestCarsDbContext dbContext) {
        this.dbContext = dbContext;
      }


      public async Task<IActionResult> Index() {
        var manufacturers = await dbContext.Manufacturers.ToListAsync();
        return View(manufacturers);
      }
    }
}