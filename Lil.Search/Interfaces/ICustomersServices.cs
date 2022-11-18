using Lil.Search.Models;
using System.Threading.Tasks;

namespace Lil.Search.Interfaces
{
    public interface ICustomersServices
    {
        Task<Customer> GetAsync(string id);
    }
}
