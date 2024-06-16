using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Context;
using Pump_equipment.Data.Entities;
using Pump_equipment.Data.Repositories;
using Pump_equipment.DTO;
using System.Data;

namespace Pump_equipment.Services
{
    /// <summary>
    /// Сервис материалов
    /// </summary>
    public class MaterialService
    {
        private readonly MaterialRepository _materilRepositories;
        private readonly PumpDbContext _db;

        public MaterialService(PumpDbContext db, MaterialRepository materialRepositories)
        {
            _materilRepositories = materialRepositories;
            _db = db;
        }

        /// <summary>
        /// Получение всех материалов
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MaterialDto>> GetAllMaterialsAsync()
        {
            var query = _materilRepositories.GetAllMaterials().Select(x => new MaterialDto
            {
                Guid = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
            var result = await query.ToListAsync();

            return result;
        }

        /// <summary>
        /// Создание мотора
        /// </summary>
        /// <param name="materialDto"></param>
        public async Task CreateMaterialAsync(MaterialDto materialDto)
        {
            var materialEntity = new MaterialEntity
            {
                Id = Guid.NewGuid(),
                Name = materialDto.Name,
                Description = materialDto.Description,
            };
            _materilRepositories.CreateMaterial(materialEntity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Обновление материала
        /// </summary>
        /// <param name="materialDto"></param>
        /// <returns></returns>
        public async Task<MaterialDto> UpdateMaterialAsync(MaterialDto materialDto)
        {
            var materialEntity = new MaterialEntity
            {
                Id = materialDto.Guid,
                Name = materialDto.Name,
                Description = materialDto.Description,
            };
            _materilRepositories.UpdateMaterial(materialEntity);
            await _db.SaveChangesAsync();

            return materialDto;
        }

        /// <summary>
        /// Удаление материала
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataException"></exception>
        public async Task DeleteMaterialAsync(Guid id)
        {
            var motor = _db.Materials.Find(id) ??
                throw new DataException($"Отсутвует материал по этому идентификатору {id}");

            _materilRepositories.DeleteMaterial(motor);
            await _db.SaveChangesAsync();
        }
    }
}
