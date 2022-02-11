using Microsoft.AspNetCore.Http;

namespace BilliWebApp.Models.Motorcycle
{
    public class SetMotorcycleImage
    {
        public string ID { get; set; }

        public IFormFile ImgURL { get; set; }
    }
}
