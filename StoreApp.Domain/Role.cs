using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain
{
    public class Role
    {
        public int role_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public ICollection<Staff> Staff { get; set; }
    }
}
