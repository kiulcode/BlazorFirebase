using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
        {
            var result = await _productService.CreateProduct(product);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
        {
            await _productService.UpdateProduct(product);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Document deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return products != null
                ? Ok(products)
                : NotFound("There are no documents");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productService.GetProductById(id);

            return product != null
                ? Ok(product)
                : NotFound("There are no document");
        }
    }
}