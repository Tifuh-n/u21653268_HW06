using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework6_u21653268.Models
{
    public class Store
    {
        public int store_id { get; set; }
        public string store_name { get; set; }
        public virtual ICollection<stock> stocks { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}