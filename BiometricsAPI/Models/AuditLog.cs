using System.ComponentModel.DataAnnotations;

namespace BiometricsAPI.Models
{
    public class AuditLog
    {
        [Key]
        public int StudentId { get; set; } 
        public string Action { get; set; }
        public DateTime VerificationTimestamp { get; set; }
    }
}
