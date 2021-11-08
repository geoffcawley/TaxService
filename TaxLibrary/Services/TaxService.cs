using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxLibrary.Models;
using TaxService.Models;
using TaxService.Services;

namespace TaxLibrary.Services
{
    class TaxService : ITaxService
    {
        private TaxCalculator taxCalculator;

        TaxService(TaxCalculator taxCalculator)
        {
            this.taxCalculator = taxCalculator;
        }

        public async Task<float> GetRateAsync(string zip)
        {
            return await taxCalculator.GetRateAsync(zip);
        }

        public async Task<float> GetTotalTaxAsync(IOrder order)
        {
            return await taxCalculator.GetTotalTaxAsync(order);
        }
    }
}
