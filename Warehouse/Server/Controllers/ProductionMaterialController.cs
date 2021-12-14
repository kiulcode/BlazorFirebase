using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionMaterialController : Controller
    {
        private readonly ProductionMaterialService _productionMaterialService;

        public ProductionMaterialController(ProductionMaterialService productionMaterialService)
        {
            _productionMaterialService = productionMaterialService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductionMaterial
            ([FromBody] ProductionMaterialModel productionMaterial)
        {
            var result = await _productionMaterialService
                .CreateProductionMaterial(productionMaterial);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductionMaterial
            ([FromBody] ProductionMaterialModel productionMaterial)
        {
            await _productionMaterialService.UpdateProductionMaterial(productionMaterial);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionMaterial(string id)
        {
            await _productionMaterialService.DeleteProductionMaterial(id);
            return Ok("Document deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductionMaterials()
        {
            var productionMaterials = await _productionMaterialService.GetAllProductionMaterials();

            return productionMaterials != null
                ? Ok(productionMaterials)
                : NotFound("There are no documents");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionMaterialById(string id)
        {
            var productionMaterial = await _productionMaterialService.GetProductionMaterialById(id);

            return productionMaterial != null
                ? Ok(productionMaterial)
                : NotFound("There are no document");
        }
    }
}