using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class SalesServices : ISalesServices
    {
        private readonly IHttpClientFactory _http;
        public SalesServices(IHttpClientFactory httpClientFactory)
        {
            this._http = httpClientFactory;
        }
        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = _http.CreateClient("salesService");

            var response = await client.GetAsync($"api/Sales/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var orders = JsonConvert.DeserializeObject<ICollection<Order>>(content);

                return orders;
            }

            return null;
        }
    }
}
