using Lil.Search.Models;
using System.Threading.Tasks;

namespace Lil.Search.Interfaces
{
    public interface IProductsServices
    {
        Task<Product> GetAsync(string id);
    }
}
