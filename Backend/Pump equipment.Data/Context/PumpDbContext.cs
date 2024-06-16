using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Entities;


namespace Pump_equipment.Data.Context
{
    public class PumpDbContext : DbContext
    {
        public DbSet<PumpEntity> Pumps { get; set; }
        public DbSet<MotorEntity> Motors { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public PumpDbContext(DbContextOptions<PumpDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PumpEntity>()
                .HasOne(p => p.Motor)
                .WithMany(m => m.Pumps);

            modelBuilder.Entity<PumpEntity>()
                .HasOne(p => p.MaterialHull)
                .WithMany(m => m.BodyMaterialPumps);

            modelBuilder.Entity<PumpEntity>()
                .HasOne(p => p.ImpellerMaterial)
                .WithMany(m => m.ImpellerMaterialPumps);
        }
    }
}
