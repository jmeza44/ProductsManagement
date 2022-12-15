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
            return Ok(new OperationResult<List<Product>>
            {
                Message = "Success",
                Description = $"{products.Count()} Product(s) found",
                Result = products
            });
        }

        [HttpGet("GetById")]
        public IActionResult GetProductByCode([FromQuery] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new OperationResult<string>
                {
                    Message = "Error",
                    Description = "Missing id on query params"
                });
            }
            var product = _productsService.GetProductByCode(id.Value);
            if (product == null)
            {
                return NotFound(new OperationResult<string>
                {
                    Message = "Error",
                    Description = $"Id {id} couldn't be found"
                });
            }
            return Ok(new OperationResult<Product>
            {
                Message = "Success",
                Description = $"Product with id {id} found",
                Result = product
            });
        }
        [HttpGet("GetByDescription")]
        public IActionResult GetProductByDescription([FromQuery] string description)
        {
            if (String.IsNullOrEmpty(description))
            {
                return BadRequest(new OperationResult<List<Product>>
                {
                    Message = "Error",
                    Description = "Missing description on query params"
                });
            }
            var products = _productsService.GetProductsByDescription(description);
            return Ok(new OperationResult<List<Product>>
            {
                Message = "Success",
                Description = $"{products.Count()} Product(s) found",
                Result = products
            });
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductVM product)
        {
            var _product = _productsService.AddProduct(product);
            return Ok(new OperationResult<Product>
            {
                Message = "Success",
                Description = "Product added properly",
                Result = _product
            });
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromQuery] int? id, [FromBody] ProductVM product)
        {
            if (!id.HasValue)
            {
                return BadRequest(new OperationResult<string>
                {
                    Message = "Error",
                    Description = "Missing id on query params"
                });
            }
            var _product = _productsService.UpdateProduct(id.Value, product);
            if (_product == null)
            {
                return NotFound(new OperationResult<string>
                {
                    Message = "Error",
                    Description = $"Id {id} couldn't be found"
                });
            }
            return Ok(new OperationResult<Product>
            {
                Message = "Success",
                Description = "Product updated properly",
                Result = _product
            });
        }
    }
}
