using Microsoft.AspNetCore.Mvc;
using Pump_equipment.DTO;
using Pump_equipment.Services;

namespace Pump_equipment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotorController : Controller
    {
        private readonly MotorService _motorService;

        public MotorController(MotorService motorService)
        {
            _motorService = motorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorDto>>> GetAllMotorAsync()
        {
            var dto = await _motorService.GetAllMotorAsync();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMotorAsync(MotorDto motor)
        {
            await _motorService.CreateMotorAsync(motor);
            return Ok();
        }

        [HttpPut]
        public async Task<MotorDto> UpdateMotorAsync(MotorDto motorDto)
        {
            await _motorService.UpdateMotorAsync(motorDto);
            return motorDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMotorAsync(Guid id)
        {
            await _motorService.DeleteMotorAsync(id);
            return NoContent();
        }
    }
}
