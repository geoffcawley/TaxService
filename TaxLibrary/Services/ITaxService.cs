using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxLibrary.Models;

namespace TaxLibrary.Services
{
    public interface ITaxService
    {
        public ITaxCalculator taxCalculator { get; set; }
        Task<float> GetRateAsync(string zip);

        Task<float> GetTotalTaxAsync(IOrder order);
    }
}
