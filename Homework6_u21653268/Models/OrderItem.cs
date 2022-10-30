using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework6_u21653268.Models
{
    public class OrderItem
    {
        public int order_id { get; set; }
        public int item_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal list_price { get; set; }
        public virtual product product { get; set; }
        public virtual Order order { get; set; }
    }
}