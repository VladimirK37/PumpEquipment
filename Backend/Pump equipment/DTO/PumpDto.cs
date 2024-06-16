using Pump_equipment.Data.Entities;

namespace Pump_equipment.DTO;

/// <summary>
/// Отображение насоса
/// </summary>
public class PumpDto
{
    /// <summary>
    /// Идентификатор насоса
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование насоса
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Максимальное давление насоса
    /// </summary>
    public double MaxPressure { get; set; }

    /// <summary>
    /// Температура жидкости насоса
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// Вес насоса
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Описание насоса
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    ///  Изображение насоса
    /// </summary>
    public string? Picture { get; set; }

    /// <summary>
    /// Цена насоса
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Мотор насоса
    /// </summary>
    public MotorEntity MotorEntity { get; set; } = default!;

    /// <summary>
    /// Материал корпуса насоса
    /// </summary>
    public MaterialEntity? MaterialHull { get; set; } = default!;

    /// <summary>
    /// Материал рабочего колеса насоса
    /// </summary>
    public MaterialEntity? ImpellerMaterial { get; set; } = default!;
}
