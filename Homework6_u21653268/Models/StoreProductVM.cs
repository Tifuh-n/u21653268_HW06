using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework6_u21653268.Models
{
    public class StoreProductVM
    {
        public int product_id { get; set; }
        public List<StoreProduct> StoreProducts { get; set; }
        public product productObj { get; set; }
    }
}