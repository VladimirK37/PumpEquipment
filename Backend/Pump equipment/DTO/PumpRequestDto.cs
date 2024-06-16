namespace Pump_equipment.DTO;

/// <summary>
/// Форма добавления насоса
/// </summary>
public class PumpRequestDto
{

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Максимальное давление
    /// </summary>
    public double MaxPressure { get; set; }

    /// <summary>
    /// Температура жидкости
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Идентификатор мотора
    /// </summary>
    public Guid MotorId { get; set; } = default!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    ///  Изображение
    /// </summary>
    public string Picture { get; set; } = default!;

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Идентификатор материал корпуса
    /// </summary>
    public Guid? MaterialHullId { get; set; }

    /// <summary>
    /// Идентификатор материал рабочего колеса
    /// </summary>
    public Guid? ImpellerMaterialId { get; set; }
}
