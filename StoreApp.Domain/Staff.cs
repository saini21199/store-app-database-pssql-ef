using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain
{
    public class Staff
    {
        public int staff_id { set; get; }
        public string Staff_name { get; set; }
        public string phone_no { get; set; }
        public int role_id { get; set; }
        public int address_id { get; set; }
        public Role roles { get; set; }
        public Address addresses { get; set; }
    }
}
