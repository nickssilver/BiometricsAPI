using BiometricsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BiometricsAPI.Data
{
    public class BiometricsContext : DbContext
    {
        public BiometricsContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
        }

        public DbSet<Biometric> Biometrics { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
       
    }
}
    
