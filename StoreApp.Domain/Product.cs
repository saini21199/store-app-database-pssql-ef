using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain
{
    public class Product
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
        public int sellingPrice { get; set; }
        public int costPrice { get; set; }
        public int category_id { get; set; }

        public ICollection<PurchaseOrder> purchaseorder { get; set; }
        public Category categories { get; set; }

        public Inventory inventory { get; set; }
    }
}
