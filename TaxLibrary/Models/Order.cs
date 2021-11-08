using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxLibrary.Models;

namespace TaxService.Models
{
    public class Order : IOrder
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public Line_Items[] line_items { get; set; }

        public float GetTotal()
        {
            return line_items.Select(i => i.unit_price * i.quantity).Sum();
        }
    }

    public class Line_Items
    {
        public int quantity { get; set; }
        public float unit_price { get; set; }
        public string product_tax_code { get; set; }
    }

}
