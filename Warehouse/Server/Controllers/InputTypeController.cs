using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Server.Services;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputTypeController : Controller
    {
        private readonly InputTypeService _inputTypeService;

        public InputTypeController(InputTypeService inputTypeService)
        {
            _inputTypeService = inputTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInputType([FromBody] InputTypeModel inputType)
        {
            var result = await _inputTypeService.CreateInputType(inputType);
            return result != null
                ? Ok(result)
                : BadRequest("Input type already exists");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInputType([FromBody] InputTypeModel inputType)
        {
            await _inputTypeService.UpdateInputType(inputType);
            return Ok("Input type updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInputType(string id)
        {
            await _inputTypeService.DeleteInputType(id);
            return Ok("Input type deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInputsTypes()
        {
            var inputs = await _inputTypeService.GetAllInputsTypes();

            return inputs != null
                ? Ok(inputs)
                : NotFound("No inputs types found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInputTypeById(string id)
        {
            var input = await _inputTypeService.GetInputTypeById(id);

            return input != null
                ? Ok(input)
                : NotFound("No inputs types found");
        }
    }
}