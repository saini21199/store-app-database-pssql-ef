using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain
{
    public class Address
    {
        public int address_id { get; set; }
        public string addressLine_1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public long pincode { get; set; }
        public ICollection<Staff> Staff { get; set; }

    }
}
