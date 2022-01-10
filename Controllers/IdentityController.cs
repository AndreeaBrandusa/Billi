using BilliWebApp.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BilliWebApp.Controllers
{
    public class IdentityController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginModel model)
        {
            return null;
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
