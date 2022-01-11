using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Entities
{
    public class Motorcycle
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Details { get; set; }

        public MotorcycleImage Image { get; set; }
    }
}
