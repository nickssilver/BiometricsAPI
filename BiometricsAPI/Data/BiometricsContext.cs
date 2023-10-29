using BiometricsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace BiometricsAPI.Data
{
    public class BiometricsContext : DbContext
    {
        public BiometricsContext(DbContextOptions<BiometricsContext> options) : base(options)
        {
        }

        public DbSet<BiometricModel> Biometrics { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<StudentModel> Register { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiometricModel>().ToTable("Biometrics");
            modelBuilder.Entity<AuditLog>().ToTable("AuditLogs");
            modelBuilder.Entity<BiometricModel>().HasKey(b => b.StudentId);
            modelBuilder.Entity<AuditLog>().HasKey(a => a.StudentId);
            modelBuilder.Entity<StudentModel>().HasNoKey();
            modelBuilder.Entity<BiometricModel>()
            .Property(b => b.StudentId)
            .ValueGeneratedNever();
        }


    }
}

