using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain
{
    public class PurchaseOrder
    {
        public int order_id { get; set; }
        public DateTime supply_date { get; set; }
        public int supplier_id { get; set; }
        public int product_id { get; set; }
        public Product products { get; set; }
        public Supplier suppliers { get; set; }
    }
}
