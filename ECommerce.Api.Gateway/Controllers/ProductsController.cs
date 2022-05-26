using ECommerce.Api.Gateway.Interfaces;
using ECommerce.Api.Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Gateway.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {            
            var result = await _productsService.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsAsync(int id)
        {
            var result = await _productsService.GetProductAsync(id);
            
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var result = await _productsService.CreateProductAsync(product);
            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var result = await _productsService.EditProductAsync(product);
            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var result = await _productsService.DeleteProductAsync(new Product() { ProductID = id });
            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
