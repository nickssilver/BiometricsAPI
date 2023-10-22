namespace BiometricsAPI.Models
{
    public class AuditLog
    {
        public int LogId { get; set; } // Primary Key
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Action { get; set; }
        public DateTime VerificationTimestamp { get; set; } // Timestamp
    }

}
