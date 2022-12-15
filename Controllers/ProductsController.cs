using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Data.Models;
using ProductsManagement.Data.Services;
using ProductsManagement.Data.ViewModels;

namespace ProductsManagement.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productService)
        {
            _productsService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productsService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetByCode")]
        public IActionResult GetProductByCode([FromQuery]int code)
        {
            var product = _productsService.GetProductByCode(code);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("GetByDescription")]
        public IActionResult GetProductByDescription([FromQuery]string description)
        {
            var products = _productsService.GetProductsByDescription(description);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductVM product)
        {
            _productsService.AddProduct(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromQuery]int id, [FromBody]ProductVM product)
        {
            var _product = _productsService.UpdateProduct(id, product);
            if (_product == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
