using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaxLibrary.Models;
using System.Text;

namespace TaxService.Models
{
    public class TaxCalculator
    {
        public static HttpClient client = new HttpClient() { 
            BaseAddress = new Uri("https://api.taxjar.com/v2/"),
        };

        public TaxCalculator()
        {
            client.DefaultRequestHeaders.Add("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");
        }

        public async Task<float> GetTotalTaxAsync(IOrder order)
        {
            var orderJson = JsonConvert.SerializeObject(order);
            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("taxes", content);
            var responseContent = await System.Text.Json.JsonSerializer.DeserializeAsync<TaxesResponseRootObject>(await response.Content.ReadAsStreamAsync());
            return responseContent.tax.amount_to_collect;
        }

        public async Task<float> GetRateAsync(string zip)
        {
            HttpResponseMessage response = await client.GetAsync($"rates/{zip}");
            var rateResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<RateResponseRootObject>(await response.Content.ReadAsStreamAsync());
            return float.Parse(rateResponse.rate.combined_rate);
        }
    }
}
