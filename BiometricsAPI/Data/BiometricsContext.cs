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
        public DbSet<AuditLogs> AuditLogs { get; set; }
        public DbSet<StudentModel> Register { get; set; }
        public DbSet<Biousers> Biousers { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiometricModel>().ToTable("Biometrics");
            modelBuilder.Entity<AuditLogs>().ToTable("AuditLogs");
            modelBuilder.Entity<BiometricModel>().HasKey(b => b.StudentId);
            modelBuilder.Entity<AuditLogs>().HasKey(a => a.StudentId);
            modelBuilder.Entity<StudentModel>().HasNoKey();
            modelBuilder.Entity<BiometricModel>()
            .Property(b => b.StudentId)
            .ValueGeneratedNever();

               modelBuilder.Entity<BiometricModel>()
             .Property(b => b.Arrears)
             .HasPrecision(18, 2); // Example precision and scale

               modelBuilder.Entity<StudentModel>()
              .Property(s => s.Arrears)
              .HasPrecision(18, 2); // Example precision and scale

            modelBuilder.Entity<AdminUser>()
               .HasKey(a => a.Username);

            modelBuilder.Entity<Biousers>()
                .HasIndex(u => u.Pin)
                .IsUnique();
        }


    }
}
