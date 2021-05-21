using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class Supplier
    {
        public int supplier_id { get; set; }
        public string  sup_name { get; set; }
        public string phone_no { get; set; }
        public string city { get; set; }
        public string email { get; set; }

        public ICollection<Product> Product { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
