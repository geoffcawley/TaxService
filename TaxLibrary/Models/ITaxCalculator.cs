using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxLibrary.Models
{
    public interface ITaxCalculator
    {
        public Task<float> GetTotalTaxAsync(IOrder order);
        public Task<float> GetRateAsync(string zip);
    }
}
