using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Data.Services;
using ProductsManagement.Data.ViewModels;

namespace ProductsManagement.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;
        public ProductsController(ProductsService productService)
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
        public IActionResult GetProductByCode([FromQuery]string code)
        {
            var product = _productsService.GetProductByCode(code);
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
        public IActionResult UpdateProduct([FromBody]ProductVM product)
        {
            _productsService.UpdateProduct(product);
            return Ok();
        }
    }
}
