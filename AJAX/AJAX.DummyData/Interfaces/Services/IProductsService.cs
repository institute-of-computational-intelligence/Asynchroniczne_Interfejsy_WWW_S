using AJAX.DummyData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AJAX.DummyData.Interfaces.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync(int? quantity);
        Task<Product> GetByIdAsync(int productId);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteByIdAsync(int productId);
    }
}
