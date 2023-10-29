namespace BiometricsAPI.Models
{
    public class AuditLog
    {
        public int Id { get; set; } // Primary Key, auto-increment
        public string StudentId { get; set; } // Foreign Key
        public string StudentName { get; set; }
        public DateTime VerificationTimestamp { get; set; } // Timestamp
    }
}
