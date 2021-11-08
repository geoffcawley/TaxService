using System;
using TaxService.Models;

namespace TaxClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            var taxrate = taxCalculator.GetRateAsync("10801").GetAwaiter().GetResult();

            var order = new Order {
                from_country = "US", from_state = "TX", from_zip = "77057",
                to_country = "US", to_zip = "10801", to_state = "NY",
                amount = 1000, shipping = 45,
                line_items = new Line_Items[0],
            };

            var totalTax = taxCalculator.GetTotalTaxAsync(order).GetAwaiter().GetResult();

            return;
        }
    }
}
