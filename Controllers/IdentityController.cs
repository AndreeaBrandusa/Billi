using BilliWebApp.Models.Identity;
using BilliWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BilliWebApp.Controllers
{
    public class IdentityController : Controller
    {
        private IdentityService _identityService;

        public IdentityController(IdentityService service)
        {
            _identityService = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginModel model)
        {
            _identityService.Login(model);
            return null;
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
