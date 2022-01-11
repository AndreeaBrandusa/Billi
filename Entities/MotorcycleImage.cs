using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Entities
{
    public class MotorcycleImage
    {
        public string ID { get; set; }

        public byte[] Image { get; set; }

        public Motorcycle Motorcycle { get; set; }
    }
}
