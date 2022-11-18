using Lil.Sales.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Lil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider _salesProvider;
        public SalesController(ISalesProvider salesProvider)
        {
            this._salesProvider = salesProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var orders = await _salesProvider.GetAsync(customerId);
            try
            {
                if (orders != null && orders.Any())
                {
                    return Ok(orders);
                }

                return NotFound();
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
