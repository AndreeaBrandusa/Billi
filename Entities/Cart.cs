using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Entities
{
    public class Cart
    {
        public string CartID { get; set; }

        public string UserID { get; set; }

        public IEnumerable<CartContent> CartContents { get; set; }
    }
}
