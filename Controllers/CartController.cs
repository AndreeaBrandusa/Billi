using BilliWebApp.Models.Cart;
using BilliWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Controllers
{
    [Authorize]
    [Route("[controller]")]

    public class CartController : Controller
    {
        private CartService _service;

        public CartController(CartService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Cart()
        {
            return View(await _service.GetCart(UserId));
        }

        string UserId
        { 
            get => User.Claims.First(c => Equals(c.Type, "id"))?.Value;
        }

        [HttpPost(nameof(AddToCart))]
        public async Task<IActionResult> AddToCart(AddToCartProduct model)
        {
            if (!await _service.AddToCart(model, UserId))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
