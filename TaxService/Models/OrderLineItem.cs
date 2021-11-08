using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    public class OrderLineItem
    {
        public int quantity { get; set; }
        public float unit_price { get; set; }
        public string product_tax_code { get; set; }
    }
}
