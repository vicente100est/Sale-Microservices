using Lil.Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Products.DAL
{
    public class ProductsProvider : IProductProvider
    {
        private List<Product> _repo = new List<Product>();
        public ProductsProvider()
        {
            for (int i = 0; i <100; i++)
            {
                _repo.Add(new Product
                {
                    Id = (i + 1).ToString(),
                    Name = $"Producto {i + 1}",
                    Price = (double)i * 3.14
                });
            }
        }

        /// <summary>
        /// Select data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Products List</returns>
        public Task<Product> GetAsync(string id)
        {
            var lstProduct = _repo.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(lstProduct);
        }
    }
}
