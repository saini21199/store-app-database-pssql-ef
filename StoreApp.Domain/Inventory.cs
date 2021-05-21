using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain
{
    public class Inventory
    {
        public int quantity { get; set; }
        public int product_id { get; set; }
        public Product product { get; set; }
    }
}
