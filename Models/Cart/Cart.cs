using System.Collections.Generic;

namespace BilliWebApp.Models.Cart
{
    public class Cart
    {
        public List<CartProduct> Products { get; set; }
        
        public float Tax { get; set; }

        public float Subtotal { get; set; }
    }
}
