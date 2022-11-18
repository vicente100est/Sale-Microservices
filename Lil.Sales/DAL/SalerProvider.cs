using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DAL
{
    public class SalerProvider : ISalesProvider
    {
        private readonly List<Order> _repo = new List<Order>();
        public SalerProvider()
        {
            _repo.Add(new Order()
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem(){ OrderId = "0001", Price = 50, ProvidesId = "23", Quantity = 2 }
                }
            });
        }
        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = _repo.Where(c => c.CustomerId == customerId).ToList();
            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
