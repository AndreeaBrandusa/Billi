using Microsoft.AspNetCore.Http;

namespace BilliWebApp.Models.Motorcycle
{
    public class AddMotorcycle
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Details { get; set; }

        public IFormFile Img { get; set; }
    }
}
