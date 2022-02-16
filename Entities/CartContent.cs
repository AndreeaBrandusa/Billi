using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Entities
{
    public class CartContent
    {
        public string CartID { get; set; }

        public string MotorcycleID { get; set; }

        public int Quantity { get; set; }

        public Cart Cart { get; set; }
    }
}
