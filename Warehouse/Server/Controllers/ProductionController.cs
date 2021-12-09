using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : Controller
    {
        private readonly ProductionService _productionService;

        public ProductionController(ProductionService productionService)
        {
            _productionService = productionService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduction([FromBody] ProductionModel production)
        {
            var result = await _productionService.CreateProduction(production);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduction([FromBody] ProductionModel production)
        {
            await _productionService.UpdateProduction(production);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduction(string id)
        {
            await _productionService.DeleteProduction(id);
            return Ok("Document deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductions()
        {
            var productions = await _productionService.GetAllProductions();

            return productions != null
                ? Ok(productions)
                : NotFound("There are no documents");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionById(string id)
        {
            var production = await _productionService.GetProductionById(id);

            return production != null
                ? Ok(production)
                : NotFound("There are no document");
        }
    }
}