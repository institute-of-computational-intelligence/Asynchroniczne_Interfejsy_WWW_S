﻿using System;
using System.Collections.Generic;
using System.Text;
using AJAX.DummyData.Models;
using Bogus;

namespace AJAX.DummyData.Services
{
    public class ProductService : IProductService
    {
        private IList<Product> _products;
        private readonly Faker<Product> _productFake;

        public ProductService()
        {
            int productIdCount = 1;
            _products = new List<Product>();
            var availableProducts= new[] { "apple", "banana", "strawberry" };
            Randomizer.Seed = new Random(8675309);
            _productFake = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => productIdCount++)
                .RuleFor(x => x.ProductName, f => f.PickRandom(availableProducts))
                .RuleFor(x => x.Price, f => f.Random.Number(100) + Math.Round(f.Random.Decimal(), 2))
                .RuleFor(x => x.Amount, f => f.Random.Number(100) + Math.Round(f.Random.Double(), 2))
                .RuleFor(x=>x.ExpirationDate, f=>f.Date.Recent(0)); 

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public IList<Product> Get()
        {
            if (_products.Count == 0)
            {
                int numberOfObjects = new Random().Next(0, 100);
                _products = _productFake.Generate(numberOfObjects);
            }
            return _products;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Product Post(Product model)
        {
            throw new NotImplementedException();
        }

        public Product Put(Product model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
