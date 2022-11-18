using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IHttpClientFactory _http;
        public ProductsServices(IHttpClientFactory httpClientFactory)
        {
            this._http = httpClientFactory;
        }

        public async Task<Product> GetAsync(string id)
        {
            var client = _http.CreateClient("productsServices");

            var response = await client.GetAsync($"api/Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var product = JsonConvert.DeserializeObject<Product>(content);

                return product;
            }
            return null;
        }
    }
}
