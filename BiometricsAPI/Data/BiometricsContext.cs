using BiometricsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BiometricsAPI.Data
{
    public class BiometricsContext : DbContext
    {
        public BiometricsContext(DbContextOptions<BiometricsContext> options) : base(options)
        {
        }

        public DbSet<Biometric> Biometrics { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biometric>().ToTable("Biometrics");
            modelBuilder.Entity<AuditLog>().ToTable("AuditLogs");
            modelBuilder.Entity<Biometric>().HasKey(b => b.StudentId);
            modelBuilder.Entity<AuditLog>().HasKey(a => a.StudentId);
            modelBuilder.Entity<Biometric>()
            .Property(b => b.StudentId)
            .ValueGeneratedNever();
        }


    }
}

