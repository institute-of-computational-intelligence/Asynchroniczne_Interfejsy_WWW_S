using AJAX.DummyData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJAX.DummyData.Services
{
    public interface IProductService
    {
        IList<Product> Get();
        Product Get(int id);
        Product Post(Product product);
        Product Put(Product product, int id);
        void Delete(int id);
    }
}
