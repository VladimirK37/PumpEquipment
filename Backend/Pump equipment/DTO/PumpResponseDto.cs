using Pump_equipment.Data.Entities;

namespace Pump_equipment.DTO
{
    public class PumpResponseDto
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
        public MotorDto MotorEntity { get; set; } = default!;

        /// <summary>
        /// Материал корпуса насоса
        /// </summary>
        public MaterialDto? MaterialHull { get; set; } = default!;

        /// <summary>
        /// Материал рабочего колеса насоса
        /// </summary>
        public MaterialDto? ImpellerMaterial { get; set; } = default!;
    }
}
