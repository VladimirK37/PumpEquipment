using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Context;
using Pump_equipment.Data.Entities;

namespace Pump_equipment.DataExtetion;
public static class DataExtetion
{
    /// <summary>
    /// Миграция базы данных
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<PumpDbContext>()
                      ?? throw new InvalidOperationException();
        context.Database.Migrate();

        Seed(context);

        return app;
    }

    /// <summary>
    /// Добавление первоначальных значений в базу данных
    /// </summary>
    /// <param name="context"></param>
    public static void Seed(PumpDbContext context)
    {
        if (context.Pumps.Any())
        {
            return;
        }

        var motors = new MotorEntity[]
        {
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor A", Power = 5, Current = 10, NominalSpeed = 1500, Description = "Высокоэффективный мотор", Price = 5000M , Motor = "Motor_1"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor B", Power = 7, Current = 12, NominalSpeed = 1600, Description = "Среднеэффективный мотор", Price = 6000M , Motor = "Motor_2"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor C", Power = 115, Current = 6, NominalSpeed = 1500, Description = "Высокоэффективный мотор", Price = 5000M , Motor = "Motor_3"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor D", Power = 227, Current = 2, NominalSpeed = 1600, Description = "Среднеэффективный мотор", Price = 26000M , Motor = "Motor_4"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor F", Power = 235, Current = 9, NominalSpeed = 1500, Description = "Высокоэффективный мотор", Price = 15000M , Motor = "Motor_5"},
        };

        var materials = new MaterialEntity[]
        {
                new MaterialEntity { Id = Guid.NewGuid(), Name = "Нержавеющая сталь", Description = "Высококачественная нержавеющая сталь" },
                new MaterialEntity { Id = Guid.NewGuid(), Name = "Чугун", Description = "Высокопрочный чугун" },
                new MaterialEntity { Id = Guid.NewGuid(), Name = "Сталь", Description = "Высокопрочный сталь" }
        };

        var pumps = new PumpEntity[]
        {
                new PumpEntity { Id = Guid.NewGuid(),Name = "Pump A", MaxPressure = 10, Temperature = 100, Weight = 50, Motor = motors[0], MaterialHull = materials[0], ImpellerMaterial = materials[0], Description = "Высокопроизводительный насос", Picture = "", Price = 15000M },
                new PumpEntity { Id = Guid.NewGuid(),Name = "Pump B", MaxPressure = 15, Temperature = 120, Weight = 60, Motor = motors[1], MaterialHull = materials[1], ImpellerMaterial = materials[1], Description = "Среднепроизводительный насос", Picture = "", Price = 17000M },
                new PumpEntity { Id = Guid.NewGuid(),Name = "Pump C", MaxPressure = 20, Temperature = 200, Weight = 70, Motor = motors[3], MaterialHull = null, ImpellerMaterial = materials[2], Description = "Высокопроизводительный насос", Picture = "", Price = 35000M },
                new PumpEntity { Id = Guid.NewGuid(),Name = "Pump D", MaxPressure = 25, Temperature = 220, Weight = 80, Motor = motors[1], MaterialHull = materials[2], ImpellerMaterial = null, Description = "Среднепроизводительный насос", Picture = "", Price = 7000M },
                new PumpEntity { Id = Guid.NewGuid(),Name = "Pump E", MaxPressure = 30, Temperature = 300, Weight = 5, Motor = motors[0], MaterialHull = materials[2], ImpellerMaterial = materials[0], Description = "Высокопроизводительный насос", Picture = "", Price = 5000M }
        };

        context.Motors.AddRange(motors);
        context.Materials.AddRange(materials);
        context.Pumps.AddRange(pumps);

        context.SaveChanges();
    }
}
