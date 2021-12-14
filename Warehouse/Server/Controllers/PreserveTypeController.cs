using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreserveTypeController : Controller
    {
        private readonly PreserveTypeService _preserveTypeService;

        public PreserveTypeController(PreserveTypeService preserveTypeService)
        {
            _preserveTypeService = preserveTypeService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePreserveType([FromBody] PreserveTypeModel preserveType)
        {
            var result = await _preserveTypeService.CreatePreserveType(preserveType);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePreserveType([FromBody] PreserveTypeModel preserveType)
        {
            await _preserveTypeService.UpdatePreserveType(preserveType);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreserveType(string id)
        {
            await _preserveTypeService.DeletePreserveType(id);
            return Ok("Document deleted");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPreservesTypes()
        {
            var preservesTypes = await _preserveTypeService.GetAllPreservesTypes();

            return preservesTypes != null
                ? Ok(preservesTypes)
                : NotFound("There are no documents");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreserveTypeById(string id)
        {
            var preserveType = await _preserveTypeService.GetPreserveTypeById(id);

            return preserveType != null
                ? Ok(preserveType)
                : NotFound("There are no document");
        }
    }
}