using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxLibrary.Models;

namespace TaxLibrary.Services
{
    public class TaxService : ITaxService
    {
        public ITaxCalculator taxCalculator { get; set; }
     
        public TaxService(ITaxCalculator taxCalculator)
        {
            this.taxCalculator = taxCalculator;
        }

        public async Task<float> GetRateAsync(string zip)
        {
            try
            {
                return await taxCalculator.GetRateAsync(zip);
            }
            catch(Exception e)
            {
                // catching exceptions in service layer as specified in coding standards but not really doing anything with them since the project is so small
                throw e;
            }
        }

        public async Task<float> GetTotalTaxAsync(IOrder order)
        {
            try
            {
                return await taxCalculator.GetTotalTaxAsync(order);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
