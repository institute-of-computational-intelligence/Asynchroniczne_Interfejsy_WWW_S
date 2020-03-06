using AJAX.DummyData.Interfaces.Services;
using AJAX.DummyData.Models;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX.DummyData.Services
{
    public class ProductsService : IProductsService
    {
        private static IList<Product> _products = CreateProductsData();

        private static IList<Product> CreateProductsData()
        {
            var firstId = 1;

            var productFaker = new Faker<Product>("en")
                .RuleFor(x => x.Id, f => firstId++)
                .RuleFor(x => x.Name, f => f.Commerce.Product())
                .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                .RuleFor(x => x.Price, f => decimal.Parse(f.Commerce.Price()));

            return productFaker.Generate(100);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int? quantity)
        {
            return await Task.Run(() => _products.Take(quantity.HasValue && quantity.Value > 0 ? quantity.Value : _products.Count()));
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await Task.Run(() => _products.Single(x => x.Id == productId));
        }

        public async Task AddAsync(Product product)
        {
            await Task.Run(() =>
            {
                var newId = _products.Max(x => x.Id) + 1;
                product.Id = newId;
                _products.Add(product);
            });
        }

        public async Task UpdateAsync(Product product)
        {
            await Task.Run(() =>
            {
                var old = _products.Single(x => x.Id == product.Id);
                old.Name = product.Name;
                old.Description = product.Description;
                old.Price = product.Price;
            });
        }

        public async Task DeleteByIdAsync(int productId)
        {
            await Task.Run(() =>
            {
                var product = _products.Single(x => x.Id == productId);
                _products.Remove(product);
            });
        }
    }
}
