using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework6_u21653268.Models
{
    public class Order
    {
        public int order_id { get; set; }
        
        public System.DateTime order_date { get; set; }
        public int store_id { get; set; }
        public virtual Store store { get; set; }
        public virtual ICollection<OrderItem> order_items { get; set; }
    }
}