using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;

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