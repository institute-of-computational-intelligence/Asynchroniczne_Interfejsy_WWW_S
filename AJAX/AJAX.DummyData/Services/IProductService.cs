using AJAX.DummyData.Model;
using System.Collections.Generic;

namespace AJAX.DummyData.Services
{
    public interface IProductService
    {
        IList<Product> Get();
        Product Get(int id);
        Product Post(Product model);
        Product Put(Product model, int id);
        void Delete(int id);
    }
}