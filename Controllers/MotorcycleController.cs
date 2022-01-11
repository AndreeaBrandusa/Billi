using BilliWebApp.Models.Motorcycle;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BilliWebApp.Controllers
{
    public class MotorcycleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View(new List<Motorcycle>
            {
                new Motorcycle
                {
                    ID = "sferresareae4e",
                    Name = "motorcycle billy"
                },
                new Motorcycle
                {
                    ID = "sferrhdgseae4e",
                    Name = "motorcycle gafi"
                },
                new Motorcycle
                {
                    ID = "sferreshfdseae4e",
                    Name = "motorcycle billi"
                }
            });
        }
    }
}
