using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJAX.DummyData.Models;
using AJAX.DummyData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJAX.WebApi.Jquery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get() {
            return Ok(_productService.Get());
        }
        //public IEnumerable<string> Get()
        //{
        //  
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
