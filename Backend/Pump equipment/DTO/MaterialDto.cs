namespace Pump_equipment.DTO;

/// <summary>
/// Форма материал
/// </summary>
public class MaterialDto
{
    /// <summary>
    /// Идентификатор материала
    /// </summary>
    public Guid Id { get; set; } = default!;

    /// <summary>
    /// Наименование материала
    /// </summary>
    public string Name { get; set; } = default!;


    /// <summary>
    /// Описание материала
    /// </summary>
    public string Description { get; set; } = default!;
}
