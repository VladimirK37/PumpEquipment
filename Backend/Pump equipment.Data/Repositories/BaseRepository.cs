using Pump_equipment.Data.Context;

namespace Pump_equipment.Data.Repositories;

public class BaseRepository<TEntityClass> where TEntityClass : class
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    protected PumpDbContext DbContext { get; }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="dbContext"></param>
    protected BaseRepository(PumpDbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Получить все entity
    /// </summary>
    /// <returns></returns>
    public IQueryable<TEntityClass> GetAll()
    {
        return DbContext.Set<TEntityClass>();
    }
}
