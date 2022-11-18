using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersServices _customer;
        private readonly IProductsServices _products;
        private readonly ISalesServices _sales;
        public SearchController(ICustomersServices customersServices,
            IProductsServices productsServices,
            ISalesServices salesServices)
        {
            this._customer = customersServices;
            this._products = productsServices;
            this._sales = salesServices;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
                return BadRequest();

            try
            {
                var customer = await _customer.GetAsync(customerId);

                var sales = await _sales.GetAsync(customerId);

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await _products.GetAsync(item.ProvidesId);

                        item.Product = product;
                    }
                }

                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
