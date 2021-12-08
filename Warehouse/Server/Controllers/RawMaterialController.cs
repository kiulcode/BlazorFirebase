using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialController : Controller
    {
        private readonly RawMaterialService _rawMaterialService;

        public RawMaterialController(RawMaterialService rawMaterialService)
        {
            _rawMaterialService = rawMaterialService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRawMaterial([FromBody] RawMaterialModel rawMaterial)
        {
            var result = await _rawMaterialService.CreateRawMaterial(rawMaterial);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRawMaterial([FromBody] RawMaterialModel rawMaterial)
        {
            await _rawMaterialService.UpdateRawMaterial(rawMaterial);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawMaterial(string id)
        {
            await _rawMaterialService.DeleteRawMaterial(id);
            return Ok("Document deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRawMaterials()
        {
            var rawMaterials = await _rawMaterialService.GetAllRawMaterials();

            return rawMaterials != null
                ? Ok(rawMaterials)
                : NotFound("There are no documents");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInputById(string id)
        {
            var rawMaterial = await _rawMaterialService.GetRawMaterialById(id);

            return rawMaterial != null
                ? Ok(rawMaterial)
                : NotFound("There are no document");
        }
    }
}