using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputController : Controller
    {
        private readonly InputService _inputService;

        public InputController(InputService inputService)
        {
            _inputService = inputService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateInput([FromBody] InputModel input)
        {
            var result = await _inputService.CreateInput(input);
            return result != null
                ? Ok(result)
                : BadRequest("Input already exists");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInput([FromBody] InputModel input)
        {
            await _inputService.UpdateInput(input);
            return Ok("Input updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInput(string id)
        {
            await _inputService.DeleteInput(id);
            return Ok("Input deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInputs()
        {
            var inputs = await _inputService.GetAllInputs();

            return inputs != null
                ? Ok(inputs)
                : NotFound("No inputs found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInputById(string id)
        {
            var input = await _inputService.GetInputById(id);

            return input != null
                ? Ok(input)
                : NotFound("No inputs found");
        }
    }
}