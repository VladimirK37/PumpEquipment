using Microsoft.AspNetCore.Mvc;
using Pump_equipment.DTO;
using Pump_equipment.Services;

namespace Pump_equipment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PumpController : Controller
    {
        private readonly PumpService _pumpService;

        public PumpController(PumpService pumpService)
        {
            _pumpService = pumpService;
        }

        /// <summary>
        /// Получение всех насосов
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PumpDto>>> GetAllNasoesAsync()
        {
            var dto = await _pumpService.GetAllPumpAsync();
            return Ok(dto);
        }

        /// <summary>
        /// Создание насоса
        /// </summary>
        /// <param name="pump"></param>
        [HttpPost]
        public async Task<ActionResult> CreatePump(PumpRequestDto pumpDto)
        {
            await _pumpService.CreatePumpAsync(pumpDto);
            return Ok();
        }

        /// <summary>
        /// Обновление насоса
        /// </summary>
        /// <param name="pump"></param>
        [HttpPut]
        public async Task<PumpResponseDto> UpdatePump(PumpResponseDto pump)
        {
            await _pumpService.UpdatePumpAsync(pump);
            return pump;
        }

        /// <summary>
        /// Удаление насоса
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePump(Guid id)
        {
            await _pumpService.DeletePumpAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Получение насоса по идентификатору
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<PumpResponseDto>> GetPumpAsync(Guid id)
        {
            var dto = await _pumpService.GetPumpAsync(id);
            return Ok(dto);
        }
    }
}
