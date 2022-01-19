using BilliWebApp.Models.Motorcycle;
using BilliWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BilliWebApp.Controllers
{
    public class MotorcycleController : Controller
    {
        private MotorcycleService _service;

        public MotorcycleController(MotorcycleService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetails(string id)
        {
            return View(_service.GetMotorcycle(id));
        }

        public async Task<IActionResult> Products()
        {
            return View(await _service.GetMotorcyclesAsync());
        }

        [HttpPost]
        public void SetImage()
        {
            var x = Request.Form.Files;
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddMotorcycle model)
        {
            if (!await _service.AddMotorcycle(model)) 
            {
                return View();
            }
            return RedirectToAction(nameof(Products));
        }
    }
}
