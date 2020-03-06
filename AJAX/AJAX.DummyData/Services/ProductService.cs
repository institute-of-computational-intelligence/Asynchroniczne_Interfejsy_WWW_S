﻿using System;
using System.Collections.Generic;
using System.Text;
using AJAX.DummyData.Model;
using Bogus;

namespace AJAX.DummyData.Services
{
    public class ProductService : IProductService
    {
        private IList<Product> _products;
        private readonly Faker<Product> _productsFaker;

        public ProductService()
        {
            int productIdCount = 1;
            _products = new List<Product>();
            var avaibleProducts = new[] { "apple", "bannana", "orange", "stawberry", "kiwi", "bread" };

            Randomizer.Seed = new Random(8675309);
            _productsFaker = new Faker<Product>()
                                    .StrictMode(true)
                                    .RuleFor(x => x.ID, f => productIdCount++)
                                    .RuleFor(x => x.Price, f => f.Random.Number(100) + Math.Round(f.Random.Decimal(), 2))
                                    .RuleFor(x => x.ExpirationDate, f => f.Date.Recent(0))
                                    .RuleFor(x => x.ProductName, f => f.PickRandom(avaibleProducts))
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
