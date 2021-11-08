using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Services
{
    interface ITaxService
    {
        Task<float> GetRateAsync();

        Task<float> GetTotalTaxAsync();
    }
}
