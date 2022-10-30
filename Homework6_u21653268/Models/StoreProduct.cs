using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework6_u21653268.Models
{
    public class StoreProduct
    {
        public int store_id { get; set; }
        public string store_name { get; set; }
        public int quantity { get; set; }
    }
}