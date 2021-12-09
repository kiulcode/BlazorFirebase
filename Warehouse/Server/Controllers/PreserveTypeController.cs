using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;

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