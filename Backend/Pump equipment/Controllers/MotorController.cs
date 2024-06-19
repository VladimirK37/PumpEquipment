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

        /// <summary>
        /// Получение всех моторов
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorDto>>> GetAllMotorAsync()
        {
            var dto = await _motorService.GetAllMotorAsync();
            return Ok(dto);
        }

        /// <summary>
        /// Создание мотора
        /// </summary>
        /// <param name="motor"></param>
        [HttpPost]
        public async Task<ActionResult> CreateMotorAsync(MotorDto motor)
        {
            await _motorService.CreateMotorAsync(motor);
            return Ok();
        }

        /// <summary>
        /// Обновление мотора
        /// </summary>
        /// <param name="motorDto"></param>
        [HttpPut]
        public async Task<MotorDto> UpdateMotorAsync(MotorDto motorDto)
        {
            await _motorService.UpdateMotorAsync(motorDto);
            return motorDto;
        }

        /// <summary>
        /// Удаление мотора по идентификатору
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMotorAsync(Guid id)
        {
            await _motorService.DeleteMotorAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Получение мотора по идентификатору
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<MotorDto>> GetMotorAsync(Guid id)
        {
            var dto = await _motorService.GetMotorAsync(id);
            return Ok(dto);
        }
    }
}
