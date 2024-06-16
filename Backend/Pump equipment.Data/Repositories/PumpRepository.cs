using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Context;
using Pump_equipment.Data.Entities;

namespace Pump_equipment.Data.Repositories
{
    /// <summary>
    /// Репозиторий насосов
    /// </summary>
    public class PumpRepository : BaseRepository<PumpEntity>
    {
        public PumpRepository(PumpDbContext context) : base(context) { }

        /// <summary>
        /// Получение всех насосов
        /// </summary>
        /// <returns></returns>
        public IQueryable<PumpEntity> GetAllPumps()
        {
            return DbContext.Pumps.AsNoTracking().Include(p => p.Motor)
                .Include(s => s.MaterialHull)
                .Include(m => m.ImpellerMaterial);
        }

        /// <summary>
        /// Добавить насос
        /// </summary>
        /// <param name="pump"></param>
        /// <returns></returns>
        public PumpEntity CreatePump(PumpEntity pump)
        {
            return DbContext.Pumps.Add(pump).Entity;
        }

        /// <summary>
        /// Обновить насос
        /// </summary>
        /// <param name="pump"></param>
        public void UpdatePump(PumpEntity pump)
        {
            DbContext.Pumps.Update(pump);
        }

        /// <summary>
        /// Удалить насос
        /// </summary>
        /// <param name="pump"></param>
        public void DeletePump(PumpEntity pump)
        {
            DbContext.Pumps.Remove(pump);
        }
    }
}
