using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var availableProducts = new[] { "apple", "banana", "orange", "strawberry", "kiwi", "bread", "candy", "fish", "meat", "potatoes" };

            Randomizer.Seed = new Random(8675309);
            _productFaker = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => productIdCount++)
                .RuleFor(x => x.Price, f => f.Random.Number(100) + Math.Round(f.Random.Decimal(), 2))
                .RuleFor(x => x.ExpirationDate, f => f.Date.Recent(0))
                .RuleFor(x => x.ProductName, f => f.PickRandom(availableProducts))
                .RuleFor(x => x.Amount, f => f.Random.Number(100) + Math.Round(f.Random.Double(), 2));
        }

        private void GenerateProducts()
        {
            if (_products.Count == 0)
                _products = _productFaker.Generate(new Random().Next(500));
        }

        public IList<Product> Get()
        {
            GenerateProducts();
            return _products;
        }

        public Product Get(int id)
        {
            GenerateProducts();
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                throw new ArgumentException("Element with given id not exist");
            return product;
        }

        public Product Post(Product model)
        {
            GenerateProducts();
            model.Id = _products.Count;
            model.Id++;
            _products.Add(model);
            return model;
        }

        public Product Put(Product model, int id)
        {
            var productToRemove = _products.FirstOrDefault(x => x.Id == id);
            if (productToRemove == null)
                throw new ArgumentException("Element with given id not exist");
            _products.Remove(productToRemove);
            model.Id = id;
            _products.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            var productToRemove = _products.FirstOrDefault(x => x.Id == id);
            if (productToRemove == null)
                throw new ArgumentException("Element with given id not exist");
            _products.Remove(productToRemove);

        }
    }
}
