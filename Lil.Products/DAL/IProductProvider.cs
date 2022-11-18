using Lil.Products.Models;
using System.Threading.Tasks;

namespace Lil.Products.DAL
{
    public interface IProductProvider
    {
        Task<Product> GetAsync(string id);
    }
}
