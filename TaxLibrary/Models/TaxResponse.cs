using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxLibrary.Models
{
    public class TaxesResponseRootObject
    {
        public TaxResponseTax tax { get; set; }
    }

    public class TaxResponseTax
    {
        public float amount_to_collect { get; set; }
        public TaxResponseBreakdown breakdown { get; set; }
        public bool freight_taxable { get; set; }
        public bool has_nexus { get; set; }
        public TaxResponseJurisdiction jurisdictions { get; set; }
        public float order_total_amount { get; set; }
        public float rate { get; set; }
        public float shipping { get; set; }
        public string tax_source { get; set; }
        public float taxable_amount { get; set; }
    }

    public class TaxResponseBreakdown
    {
        public float city_tax_collectable { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_tax_collectable { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public TaxResponseLineItem[] line_items { get; set; }
        public TaxResponseShipping shipping { get; set; }
        public float special_district_tax_collectable { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float state_tax_collectable { get; set; }
        public float state_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }
    }

    public class TaxResponseShipping
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

    public class TaxResponseLineItem
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

    public class TaxResponseJurisdiction
    {
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string state { get; set; }
    }
}
