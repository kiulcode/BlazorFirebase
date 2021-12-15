using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly StorageService _warehouseService;

        public StorageController(StorageService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorage([FromBody] StorageModel warehouse)
        {
            var result = await _warehouseService.CreateStorage(warehouse);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorage([FromBody] StorageModel warehouse)
        {
            await _warehouseService.UpdateStorage(warehouse);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage(string id)
        {
            await _warehouseService.DeleteStorage(id);
            return Ok("Document deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStorages()
        {
            var warehouse = await _warehouseService.GetAllStorages();

            return warehouse != null
                ? Ok(warehouse)
                : NotFound("There are no documents");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorageById(string id)
        { 
            var warehouse = await _warehouseService.GetStorageById(id);

            return warehouse != null
                ? Ok(warehouse)
                : NotFound("There are no document");
        }
    }
}