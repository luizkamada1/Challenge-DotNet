using Microsoft.EntityFrameworkCore;
using Challenge.Models;

namespace Challenge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<SensorRFID> Sensores { get; set; }
        public DbSet<HistoricoMovimentacao> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>().ToTable("Moto");
            modelBuilder.Entity<Zona>().ToTable("Zona");
            modelBuilder.Entity<Patio>().ToTable("Patio");
            modelBuilder.Entity<SensorRFID>().ToTable("Sensor_RFID");
            modelBuilder.Entity<HistoricoMovimentacao>().ToTable("Historico_Movimentacao");
        }
    }
}
