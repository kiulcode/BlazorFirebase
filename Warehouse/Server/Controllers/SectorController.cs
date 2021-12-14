using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : Controller
    {
        private readonly SectorService _sectorService;

        public SectorController(SectorService sectorService)
        {
            _sectorService = sectorService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSector([FromBody] SectorModel sector)
        {
            var result = await _sectorService.CreateSector(sector);
            return result != null
                ? Ok(result)
                : BadRequest("Error creating document");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSector([FromBody] SectorModel sector)
        {
            await _sectorService.UpdateSector(sector);
            return Ok("Actualized document");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(string id)
        {
            await _sectorService.DeleteSector(id);
            return Ok("Document deleted");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllSectors()
        {
            var sectors = await _sectorService.GetAllSectors();

            return sectors != null
                ? Ok(sectors)
                : NotFound("There are no documents");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectorById(string id)
        {
            var sector = await _sectorService.GetSectorById(id);

            return sector != null
                ? Ok(sector)
                : NotFound("There are no document");
        }
    }
}