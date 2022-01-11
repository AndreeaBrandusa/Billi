using BilliWebApp.Models.Identity;
using BilliWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (await _identityService.LoginAsync(model))
            {
                return RedirectToAction("Register");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (await _identityService.RegisterAsync(model))
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
    }
}
