using System;
using System.Collections.Generic;
using AJAX.DummyData.Model;
using Bogus;

namespace AJAX.DummyData.Services
{
    public class ProductService : IProductService
    {
        private IList<Product> _products;
        private readonly Faker<Product> _productFaker;

        public ProductService()
        {
            int productIdCount = 1;
            _products = new List<Product>();
            var availableProducts = new[] { "apple", "bannana", "orange", "strawberry" };
            Randomizer.Seed = new Random(8671232);
            _productFaker = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => productIdCount++)
                .RuleFor(x => x.Price, f => f.Random.Number(100) + Math.Round(f.Random.Decimal(), 2))
                .RuleFor(x => x.ExpirationDate, f => f.Date.Recent())
                .RuleFor(x => x.Name, f => f.PickRandom(availableProducts))
                .RuleFor(x => x.Amount, f => f.Random.Number(100) + Math.Round(f.Random.Double(), 2));
        }

        public void Delete(int id)
        {

            throw new NotImplementedException();
        }

        public IList<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Product Post(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Put(Product product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
