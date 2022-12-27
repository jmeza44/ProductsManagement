using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Data.Models;
using ProductsManagement.Data.Services;
using ProductsManagement.Data.ViewModels;
using ProductsManagement.Utilities;

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
            return Ok(new OperationResult<List<ProductWithIdVM>>
            {
                Message = "Success",
                Description = $"{products.Count} Product(s) found",
                Result = products
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productsService.GetProductById(id);
            if (product == null)
            {
                return NotFound(new OperationResult<string>
                {
                    Message = "Error",
                    Description = $"Id {id} couldn't be found"
                });
            }
            return Ok(new OperationResult<ProductWithIdVM>
            {
                Message = "Success",
                Description = $"Product with id {id} found",
                Result = product
            });
        }
        [HttpGet("GetByDescription")]
        public IActionResult GetProductByDescription([FromQuery] string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest(new OperationResult<List<Product>>
                {
                    Message = "Error",
                    Description = "Missing search key on query params (/GetByDescription?search=example)"
                });
            }
            var products = _productsService.GetProductsByDescription(search);
            return Ok(new OperationResult<List<ProductWithIdVM>>
            {
                Message = "Success",
                Description = $"{products.Count} Product(s) found",
                Result = products
            });
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new OperationResult<ProductVM>
                {
                    Message = "Error",
                    Description = "Invalid incoming product",
                    Result = product
                });
            }
            var _product = _productsService.AddProduct(product);
            return Ok(new OperationResult<ProductWithIdVM>
            {
                Message = "Success",
                Description = "Product added properly",
                Result = _product
            });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new OperationResult<string>
                {
                    Message = "Error",
                    Description = "Invalid incoming product"
                });
            }
            var _product = _productsService.UpdateProduct(id, product);
            if (_product == null)
            {
                return NotFound(new OperationResult<string>
                {
                    Message = "Error",
                    Description = $"Id {id} couldn't be found"
                });
            }
            return Ok(new OperationResult<ProductWithIdVM>
            {
                Message = "Success",
                Description = "Product updated properly",
                Result = _product
            });
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var _product = _productsService.DeleteProduct(id);
            if (_product == null)
            {
                return NotFound(new OperationResult<string>
                {
                    Message = "Error",
                    Description = $"Id {id} couldn't be found"
                });
            }
            return Ok(new OperationResult<ProductWithIdVM>
            {
                Message = "Success",
                Description = "Product deleted properly",
                Result = _product
            });
        }
    }
}
