using System;
using System.Collections.Generic;
using System.Text;
using AJAX.DummyData.Model;
using Bogus;

namespace AJAX.DummyData.Services
{
    public class ProductService : IProductService
    {
        public IList<Product> _products{ get; set; }
        private readonly Faker<Product> _productFaker;

        public ProductService()
        {
            int productIdCount = 1;
            _products = new List<Product>();
            var availableProducts = new[] { "apple", "pineapple", "orange", "avocado", "banana", "strawberry"};

            Randomizer.Seed = new Random(8675309);
            _productFaker = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => productIdCount++)
                .RuleFor(x => x.Price, f => f.Random.Number(100) + Math.Round(f.Random.Decimal()))
                .RuleFor(x => x.ExpirationDate, f => f.Date.Recent(0))
                .RuleFor(x => x.ProductName, f => f.PickRandom(availableProducts))
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
