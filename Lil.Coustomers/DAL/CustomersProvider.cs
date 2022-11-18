using Lil.Coustomers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Lil.Coustomers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> _repo = new List<Customer>();

        public CustomersProvider()
        {
            _repo.Add(new Customer() { ID = "1", Name = "Lucia Escobar", City = "CDMX"});
            _repo.Add(new Customer() { ID = "2", Name = "Vicente Estrada", City = "CDMX" });
            _repo.Add(new Customer() { ID = "3", Name = "Rodrigo Diaz", City = "CDMX" });
            _repo.Add(new Customer() { ID = "4", Name = "Belen Najarro", City = "CDMX" });
            _repo.Add(new Customer() { ID = "5", Name = "Juan Correa", City = "CDMX" });
        }

        public Task<Customer> GetAsync(string id)
        {
            var customer = _repo.FirstOrDefault(c => c.ID == id);
            return Task.FromResult(customer);
        }
    }
}
