using System;
using TaxLibrary.Models;
using TaxLibrary.Services;

namespace TaxClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            TaxService taxService = new TaxService(taxCalculator);
            var taxrate = taxCalculator.GetRateAsync("10801").GetAwaiter().GetResult();

            var order = new Order {
                from_country = "US", from_state = "TX", from_zip = "77057",
                to_country = "US", to_zip = "10801", to_state = "NY",
                amount = 1000, shipping = 45,
            };

            var nexusOrder = new NexusOrder
            {
                from_country = "US",
                from_state = "TX",
                from_zip = "77057",
                to_country = "US",
                to_zip = "10801",
                to_state = "NY",
                amount = 1000,
                shipping = 45,
                nexus_addresses = new NexusAddress[2]
                {
                    new NexusAddress { country = "US", state = "TX", zip = "77057", },
                    new NexusAddress { country = "US", zip = "10801", state = "NY", }
                }
            };

            // TaxJar API nexus addresses always seems to return 0 tax to collect for interstate orders, even in their postman examples
            var totalTax = taxCalculator.GetTotalTaxAsync(order).GetAwaiter().GetResult();

            var nexusTotalTax = taxCalculator.GetTotalTaxAsync(nexusOrder).GetAwaiter().GetResult();

            return;
        }
    }
}
