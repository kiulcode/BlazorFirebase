using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly WarehouseService _warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWarehouse([FromBody] WarehouseModel warehouse)
        {
            var result = await _warehouseService.CreateWarehouse(warehouse);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse([FromBody] WarehouseModel warehouse)
        {
            await _warehouseService.UpdateWarehouse(warehouse);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(string id)
        {
            await _warehouseService.DeleteWarehouse(id);
            return Ok("Document deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouse()
        {
            var warehouse = await _warehouseService.GetAllWarehouse();

            return warehouse != null
                ? Ok(warehouse)
                : NotFound("There are no documents");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseById(string id)
        { 
            var warehouse = await _warehouseService.GetWarehouseById(id);

            return warehouse != null
                ? Ok(warehouse)
                : NotFound("There are no document");
        }
    }
}