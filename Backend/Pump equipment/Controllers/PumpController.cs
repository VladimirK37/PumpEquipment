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
        /// <returns></returns>

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
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreatePump(PumpRequestDto pump)
        {
            await _pumpService.CreatePumpAsync(pump);
            return Ok();
        }

        /// <summary>
        /// Обновление насоса
        /// </summary>
        /// <param name="pump"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PumpDto> UpdatePump(PumpDto pump)
        {
            await _pumpService.UpdatePumpAsync(pump);
            return pump;
        }

        /// <summary>
        /// Удаление насоса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePump(Guid id)
        {
            await _pumpService.DeletePumpAsync(id);
            return NoContent();
        }
    }
}
