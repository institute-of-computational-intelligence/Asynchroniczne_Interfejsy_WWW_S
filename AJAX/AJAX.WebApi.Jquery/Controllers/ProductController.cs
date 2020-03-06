using AJAX.DummyData.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AJAX.WebApi.Jquery.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        private IProductService _productService { get; set; }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public string Index()
        {

            return _productService.Get();
        }
    }
}
