using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJAX.DummyData.Model;
using AJAX.DummyData.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AJAX.WebApi.Jquery.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productService.Get());
            }
            catch (Exception ex)
            {
                // logger
                return StatusCode(500, "Error occured");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_productService.Get(id));
            }
            catch (Exception ex)
            {
                // logger
                return StatusCode(500, "Error occured");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromForm] Product model)
        {
            try
            {
                return Ok(_productService.Post(model));
            }
            catch (Exception ex)
            {
                // logger
                return StatusCode(500, "Error occured");
            }
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Product model)
        {
            try
            {
                return Ok(_productService.Put(model, id));
            }
            catch (Exception ex)
            {
                // logger
                return StatusCode(500, "Error occured");
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // logger
                return StatusCode(500, "Error occured");
            }
        }
    }
}
