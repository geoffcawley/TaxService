using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    public class TaxesResponseRootObject
    {
        public Tax tax { get; set; }
    }

    public class Tax
    {
        public float amount_to_collect { get; set; }
        public Breakdown breakdown { get; set; }
        public bool freight_taxable { get; set; }
        public bool has_nexus { get; set; }
        public Jurisdictions jurisdictions { get; set; }
        public float order_total_amount { get; set; }
        public float rate { get; set; }
        public float shipping { get; set; }
        public string tax_source { get; set; }
        public float taxable_amount { get; set; }
    }

    public class Breakdown
    {
        public float city_tax_collectable { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_tax_collectable { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public TaxesResponseLine_Items[] line_items { get; set; }
        public Shipping shipping { get; set; }
        public float special_district_tax_collectable { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float state_tax_collectable { get; set; }
        public float state_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class Shipping
    {
        public float city_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public float special_district_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float special_taxable_amount { get; set; }
        public float state_amount { get; set; }
        public float state_sales_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class TaxesResponseLine_Items
    {
        public float city_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public string id { get; set; }
        public float special_district_amount { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float state_amount { get; set; }
        public float state_sales_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class Jurisdictions
    {
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string state { get; set; }
    }
}
