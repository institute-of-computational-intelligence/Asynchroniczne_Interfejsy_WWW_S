using System.Collections.Generic;
using System.Threading.Tasks;
using AJAX.DummyData.Interfaces.Services;
using AJAX.DummyData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAX.WebApi.JQuery.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get(int? quantity = null)
        {
            return await _productsService.GetProductsAsync(quantity);
        }

        [HttpGet("{productId}")]
        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _productsService.GetByIdAsync(productId);
        }

        [HttpPost]
        public async Task PostAsync(Product product)
        {
            await _productsService.AddAsync(product);
        }

        [HttpPut]
        public async Task PutAsync(Product product)
        {
            await _productsService.UpdateAsync(product);
        }

        [HttpDelete("{productId}")]
        public async Task DeleteByIdAsync(int productId)
        {
            await _productsService.DeleteByIdAsync(productId);
        }
    }
}