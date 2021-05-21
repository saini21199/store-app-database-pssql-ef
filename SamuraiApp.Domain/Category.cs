using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class Category
    {
        public int category_id { get; set; }
        public string cat_code { get; set; }
        public string cat_name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
