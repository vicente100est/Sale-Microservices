using Lil.Coustomers.Models;
using System.Threading.Tasks;

namespace Lil.Coustomers.DAL
{
    public interface ICustomersProvider
    {
        Task<Customer> GetAsync(string id);
    }
}
