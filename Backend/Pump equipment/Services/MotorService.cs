using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Context;
using Pump_equipment.Data.Entities;
using Pump_equipment.Data.Repositories;
using Pump_equipment.DTO;
using System.Data;

namespace Pump_equipment.Services
{

    /// <summary>
    /// Сервис моторов
    /// </summary>
    public class MotorService
    {
        private readonly MotorRepository _motorsRepositories;
        private readonly PumpDbContext _db;

        public MotorService(PumpDbContext db, MotorRepository motorsRepositories)
        {
            _motorsRepositories = motorsRepositories;
            _db = db;
        }

        /// <summary>
        /// Получение всех моторов
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MotorDto>> GetAllMotorAsync()
        {
            var query = _motorsRepositories.GetAllMotors().Select(x => new MotorDto
            {
                Guid = x.Id,
                Name = x.Name,
                Description = x.Description,
                Current = x.Current,
                Motor = x.Motor,
                Power = x.Power,
                NominalSpeed = x.NominalSpeed,
                Price = x.Price,
            });
            var result = await query.ToListAsync();
            return result;
        }


        /// <summary>
        /// Создание мотора
        /// </summary>
        /// <param name="motorDto"></param>
        public async Task<MotorDto> CreateMotorAsync(MotorDto motorDto)
        {
            var motorEntity = new MotorEntity
            {
                Id = Guid.NewGuid(),
                Name = motorDto.Name,
                Power = motorDto.Power,
                Current = motorDto.Current,
                NominalSpeed = motorDto.NominalSpeed,
                Motor = motorDto.Motor,
                Description = motorDto.Description,
                Price = motorDto.Price,
            };
            _motorsRepositories.CreateMotor(motorEntity);
            await _db.SaveChangesAsync();

            return motorDto;
        }

        /// <summary>
        /// Обновление мотора
        /// </summary>
        /// <param name="motorDto"></param>
        /// <returns></returns>
        public async Task<MotorDto> UpdateMotorAsync(MotorDto motorDto)
        {
            var motorEntity = new MotorEntity
            {
                Id = motorDto.Guid,
                Name = motorDto.Name,
                Power = motorDto.Power,
                Current = motorDto.Current,
                NominalSpeed = motorDto.NominalSpeed,
                Motor = motorDto.Motor,
                Description = motorDto.Description,
                Price = motorDto.Price,
            };
            _motorsRepositories.UpdateMotor(motorEntity);
            await _db.SaveChangesAsync();

            return motorDto;
        }

        /// <summary>
        /// Удаление мотора
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataException"></exception>
        public async Task DeleteMotorAsync(Guid id)
        {
            var motor = _db.Motors.Find(id) ??
                throw new DataException($"Отсутвует мотор по этому идентификатору {id}");

            _motorsRepositories.DeleteMotor(motor);
            await _db.SaveChangesAsync();
        }
    }
}
