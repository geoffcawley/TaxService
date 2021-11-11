using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxLibrary.Models
{

    public class NexusOrder : IOrder
    {
        public string to_city { get; set; }
        public string to_state { get; set; }
        public string to_zip { get; set; }
        public string to_country { get; set; }
        public string from_city { get; set; }
        public string from_state { get; set; }
        public string from_zip { get; set; }
        public string from_country { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public NexusOrderLineItem[] line_items { get; set; }
        public NexusAddress[] nexus_addresses { get; set; }

        public float GetTotalBeforeShipping()
        {
            return (line_items != null && line_items.Length > 0) ? line_items.Select(i => i.unit_price * i.quantity).Sum() : amount;
        }
    }

    public class NexusOrderLineItem
    {
        public int quantity { get; set; }
        public float unit_price { get; set; }
    }

    public class NexusAddress
    {
        public string country { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

}
