using Microsoft.AspNetCore.Mvc;
using Pump_equipment.DTO;
using Pump_equipment.Services;

namespace Pump_equipment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : Controller
    {
        private readonly MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// Получение всех материалов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAllMaterialsAsync()
        {
            var dto = await _materialService.GetAllMaterialsAsync();
            return Ok(dto);
        }

        /// <summary>
        /// Создание материала
        /// </summary>
        /// <param name="materialDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateMaterialAsync(MaterialDto materialDto)
        {
            await _materialService.CreateMaterialAsync(materialDto);
            return Ok();
        }

        /// <summary>
        /// Обновление материала
        /// </summary>
        /// <param name="materialDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<MaterialDto> UpdateMotorAsync(MaterialDto materialDto)
        {
            var material = await _materialService.UpdateMaterialAsync(materialDto);
            return material;
        }

        /// <summary>
        /// Удаление материала по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterialAsync(Guid id)
        {
            await _materialService.DeleteMaterialAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Получение материала по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDto>> GetMaterialAsync(Guid id)
        {
            var dto = await _materialService.GetMaterialAsync(id);
            return Ok(dto);
        }
    }
}
