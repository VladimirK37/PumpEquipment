namespace Pump_equipment.DTO;

/// <summary>
///  Форма мотор
/// </summary>
public class MotorDto
{
    /// <summary>
    /// Идентификатор мотора
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование мотора
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Мощность мотора
    /// </summary>
    public int Power { get; set; }

    /// <summary>
    /// Ток мотора
    /// </summary>
    public int Current { get; set; }

    /// <summary>
    /// Номинальная скорость мотора
    /// </summary>
    public int NominalSpeed { get; set; }

    /// <summary>
    /// Мотор мотора
    /// </summary>
    public string Motor { get; set; } = default!;

    /// <summary>
    /// Описание мотора
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Цена мотора
    /// </summary>
    public decimal Price { get; set; }
}
