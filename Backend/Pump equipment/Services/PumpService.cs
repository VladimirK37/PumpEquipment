using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Context;
using Pump_equipment.Data.Entities;
using Pump_equipment.Data.Repositories;
using Pump_equipment.DTO;
using System.Data;

namespace Pump_equipment.Services
{
    /// <summary>
    /// Сервис насосов
    /// </summary>
    public class PumpService
    {
        private readonly PumpRepository _pumpRepositories;
        private readonly MotorRepository _motorRepositories;
        private readonly MaterialRepository _materialRepositories;

        private readonly PumpDbContext _db;
        public PumpService(PumpDbContext db, PumpRepository pumpRepositories, MotorRepository motorRepositories, MaterialRepository materialRepositories)
        {
            _pumpRepositories = pumpRepositories;
            _motorRepositories = motorRepositories;
            _materialRepositories = materialRepositories;
            _db = db;
        }

        /// <summary>
        /// Получение всех насосов
        public async Task<IEnumerable<PumpDto>> GetAllPumpAsync()
        {
            var query = _pumpRepositories.GetAllPumps().Select(x => new PumpDto
            {
                Id = x.Id,
                Name = x.Name,
                MaxPressure = x.MaxPressure,
                Temperature = x.Temperature,
                Weight = x.Weight,
                Description = x.Description,
                Picture = x.Picture,
                Price = x.Price,
                MotorEntity = x.Motor,
                MaterialHull = x.MaterialHull,
                ImpellerMaterial = x.ImpellerMaterial
            });
            var result = await query.ToListAsync();

            return result;
        }

        /// <summary>
        /// Создание насоса
        /// </summary>
        /// <param name="pumpDto"></param>
        /// <exception cref="DataException"></exception>
        public async Task CreatePumpAsync(PumpRequestDto pumpDto)
        {
            var motorEntity = _motorRepositories.GetMotorByGuid(pumpDto.MotorId) ??
                throw new DataException("Отсутвует мотор");
            MaterialEntity? impellerMaterialEntity = pumpDto.ImpellerMaterialId != null ? _materialRepositories.GetMaterialByGuid(pumpDto.ImpellerMaterialId)??
                    throw new DataException("Отсутвует материал корпуса") : null;
            MaterialEntity? materialEntitylHull = pumpDto.ImpellerMaterialId != null ? _materialRepositories.GetMaterialByGuid(pumpDto.MaterialHullId) ??
                    throw new DataException("Отсутвует материал рабочего колеса") : null;

            var pumpEntity = new PumpEntity
            {
                Name = pumpDto.Name,
                MaxPressure = pumpDto.MaxPressure,
                Temperature = pumpDto.Temperature,
                Weight = pumpDto.Weight,
                Description = pumpDto.Description,
                Picture = pumpDto.Picture,
                Price = pumpDto.Price,
                Motor = motorEntity,
                MaterialHull = materialEntitylHull,
                ImpellerMaterial = impellerMaterialEntity
            };
            motorEntity.Pumps.Add(pumpEntity);
            if (impellerMaterialEntity != null)
                impellerMaterialEntity.BodyMaterialPumps.Add(pumpEntity);
            if (materialEntitylHull != null)
                materialEntitylHull.ImpellerMaterialPumps.Add(pumpEntity);
            _pumpRepositories.CreatePump(pumpEntity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Обновление значений насоса
        /// </summary>
        public async Task<PumpDto> UpdatePumpAsync(PumpDto pumpDto)
        {
            var motorEntity = _motorRepositories.GetMotorByGuid(pumpDto.MotorEntity.Id) ??
                throw new DataException("Отсутвует мотор");
            MaterialEntity? impellerMaterialEntity = pumpDto.ImpellerMaterial != null ?
                _materialRepositories.GetMaterialByGuid(pumpDto.ImpellerMaterial.Id)??
                    throw new DataException("Отсутвует материал корпуса") : null;
            MaterialEntity? materialEntitylHull = pumpDto.MaterialHull != null ?
                _materialRepositories.GetMaterialByGuid(pumpDto.MaterialHull.Id) ??
                    throw new DataException("Отсутвует материал рабочего колеса") : null;

            var pumpEntity = new PumpEntity
            {
                Id = pumpDto.Id,
                Name = pumpDto.Name,
                MaxPressure = pumpDto.MaxPressure,
                Temperature = pumpDto.Temperature,
                Weight = pumpDto.Weight,
                Description = pumpDto.Description,
                Price = pumpDto.Price,
                Picture = pumpDto.Picture,
                ImpellerMaterial = impellerMaterialEntity,
                MaterialHull = materialEntitylHull,
                Motor = motorEntity,
            };

            _pumpRepositories.UpdatePump(pumpEntity);
            await _db.SaveChangesAsync();

            return pumpDto;
        }

        /// <summary>
        /// Удаление насоса
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataException"></exception>
        public async Task DeletePumpAsync(Guid id)
        {
            var pumpEntity = _db.Pumps.Find(id) ??
                throw new DataException($"Отсутвует насос по этому идентификатору {id}");

            _pumpRepositories.DeletePump(pumpEntity);
            await _db.SaveChangesAsync();
        }
    }
}
