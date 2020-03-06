using System;
using System.Collections.Generic;
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
            var availableProducts = new[] { "apple", "banana", "orange", "stawberry", "kiwi", "bread" };

            Randomizer.Seed = new Random(8675309);
            _productFaker = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => productIdCount++)
                .RuleFor(x => x.Price, f => f.Random.Number(100) + Math.Round(f.Random.Decimal(), 2))
                .RuleFor(x => x.ExpirationDate, f => f.Date.Recent(0))
                .RuleFor(x => x.ProductName, f => f.PickRandom(availableProducts))
                .RuleFor(x => x.Amount, f => f.Random.Number(100) + Math.Round(f.Random.Double(), 2));

        }

        //GENERATEPRODUCTS
        void IProductService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IList<Product> IProductService.Get()
        {
            throw new NotImplementedException();
        }

        Product IProductService.Get(int id)
        {
            throw new NotImplementedException();
        }

        Product IProductService.Post(Product model)
        {
            throw new NotImplementedException();
        }

        Product IProductService.Put(Product model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
