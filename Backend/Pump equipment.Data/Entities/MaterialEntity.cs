namespace Pump_equipment.Data.Entities;

/// <summary>
/// Материал
/// </summary>
public class MaterialEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = default!;

    public virtual ICollection<PumpEntity> BodyMaterialPumps { get; set; } = new List<PumpEntity>();
    public virtual ICollection<PumpEntity> ImpellerMaterialPumps { get; set; } = new List<PumpEntity>();
}
