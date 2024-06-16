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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAllMaterialsAsync()
        {
            var dto = await _materialService.GetAllMaterialsAsync();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaterial(MaterialDto material)
        {
            await _materialService.CreateMaterialAsync(material);
            return Ok();
        }

        [HttpPut]
        public async Task<MaterialDto> UpdateMotor(MaterialDto materialDto)
        {
            await _materialService.UpdateMaterialAsync(materialDto);
            return materialDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(Guid id)
        {
            await _materialService.DeleteMaterialAsync(id);
            return NoContent();
        }

    }
}
