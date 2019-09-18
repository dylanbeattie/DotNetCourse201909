using System;
using MyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers {
    public class DemoController : Controller {
        public IActionResult Hello(string name) {
            var model = new Greeting {
                Name = name,
                FriendlyDate = DateTime.Now.ToString("D")
            };
            return View(model);
        }
    }
}
