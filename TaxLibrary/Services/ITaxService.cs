using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxLibrary.Models;
using TaxService.Models;

namespace TaxService.Services
{
    interface ITaxService
    {
        Task<float> GetRateAsync(string zip);

        Task<float> GetTotalTaxAsync(IOrder order);
    }
}
