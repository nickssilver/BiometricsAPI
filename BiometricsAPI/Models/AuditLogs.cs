namespace BiometricsAPI.Models
{
    public class AuditLogs
    {
        
        public string StudentId { get; set; } // Foreign Key
        public string StudentName { get; set; }
        public DateTime VerificationTimestamp { get; set; } // Timestamp
    }
}
