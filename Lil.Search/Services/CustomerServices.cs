using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class CustomerServices : ICustomersServices
    {
        private readonly IHttpClientFactory _http;
        public CustomerServices(IHttpClientFactory httpClientFactory)
        {
            this._http = httpClientFactory;
        }
        public async Task<Customer> GetAsync(string id)
        {
            var client = _http.CreateClient("CustomerServices");

            var response = await client.GetAsync($"api/customers/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var customer = JsonConvert.DeserializeObject<Customer>(content);

                return customer;
            }

            return null;
        }
    }
}
