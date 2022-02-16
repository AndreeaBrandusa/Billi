using BilliWebApp.Data;
using BilliWebApp.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Services
{
    public class CartService
    {
        private ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToCart(AddToCartProduct model, string userID)
        {
            if (!ValidateAddToCartModel(model, userID))
            {
                return false;
            }

            var cartID = await GetOrCreateCartId(userID);

            var cartContent = GetCartContent(cartID, model.ProductID);

            if (cartContent == null || cartContent == default)
            {
                cartContent = ConvertAddToCartProductModelToCartProductEntity(model);
                cartContent.CartID = cartID;
                _context.CartContents.Add(cartContent);
            }
            else
            {
                cartContent.Quantity += model.ProductQuantity;
            }

            await _context.SaveAsync();

            return true;
        }

        public async Task<string> CreateCartId(string userId)
        {
            var cart = new Entities.Cart()
            {
                UserID = userId,
                CartID = Guid.NewGuid().ToString()
            };

            _context.Carts.Add(cart);
            await _context.SaveAsync();

            return cart.CartID;
        }

        public async Task<Cart> GetCart(string userId)
        {
            string cartId = await GetOrCreateCartId(userId);
            if (string.IsNullOrEmpty(cartId))
            {
                return new Cart();
            }

            var products = GetProducts(cartId);

            var cart = new Cart
            {
                Products = products,
                Tax = 5,
                Subtotal = CalculatePrice(products, 5)
            };

            return cart;
        }

        private float CalculatePrice(List<CartProduct> products, float tax)
        {
            float price = 0;
            foreach (var product in products)
            {
                price += product.ProductPrice;
            }
            return price + (price/100) * tax;
        }

        private List<CartProduct> GetProducts(string cartId)
        {
            var products = _context.CartContents.Where(x => Equals(x.CartID, cartId)).Select(x => new CartProduct
            {
                ProductID = x.MotorcycleID
            }).ToList();

            if(products == null)
            {
                return new List<CartProduct>();
            }

            foreach(var product in products)
            {
                var model = _context.Motorcycles.FirstOrDefault(x => Equals(x.ID, product.ProductID));

                if(model == null || model == default) 
                {
                    continue;
                }

                product.ProductName = model.Name;
                product.ProductPrice = model.Price;

                product.ImgURL = GetImage(product.ProductID);
            }

            return products;
        }

        private string GetImage(string id)
        {
            var tmp = _context.MotorcycleImages.FirstOrDefault(x => Equals(x.ID, id));
            if (tmp == default)
            {
                return "";
            }

            return string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tmp.Image));
        }

        private async Task<string> GetOrCreateCartId(string userId)
        {
            var cartID = await GetCartId(userId);

            if (string.IsNullOrEmpty(cartID))
            {
                cartID = await CreateCartId(userId);
                if (string.IsNullOrEmpty(cartID))
                {
                    return "";
                }
            }

            return cartID;
        }

        private async Task<string> GetCartId(string userId)
        {
            var cart = _context.Carts.FirstOrDefault(x =>
                Equals(x.UserID, userId));

            if (cart == null || cart == default)
            {
                return "";
            }

            return cart.CartID;
        }

        private Entities.CartContent GetCartContent(string cartId, string productId)
        {
            var cartContent = _context.CartContents.FirstOrDefault(x => Equals(x.CartID, cartId) && Equals(x.MotorcycleID, productId));

            return cartContent;
        }

        private bool ValidateAddToCartModel(AddToCartProduct model, string userID)
        {
            if (model == null || userID == null)
            {
                return false;
            }

            return true;
        }

        private Entities.CartContent ConvertAddToCartProductModelToCartProductEntity(AddToCartProduct model)
        {
            return new Entities.CartContent
            {
                MotorcycleID = model.ProductID,
                Quantity = model.ProductQuantity
            };
        }
    }
}
