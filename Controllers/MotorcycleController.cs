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

        public async Task<IActionResult> Products()
        {
            return View(await _service.GetMotorcyclesAsync());
        }
    }
}
