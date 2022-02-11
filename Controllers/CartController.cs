﻿using BilliWebApp.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BilliWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            var cart = new Cart
            {
                Products = new List<CartProduct>
                {
                    new CartProduct
                    {
                        ProductID = "wtete51235yjyfd",
                        ProductName = "mugurel",
                        ProductPrice = 6000.4f,
                        ProductQuantity = 1
                    }
                },
                Subtotal = 470000.99f,
                Tax = 5 
            };
            return View(cart);
        }
    }
}
