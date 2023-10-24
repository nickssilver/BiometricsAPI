namespace BiometricsAPI.Models
{
    public class AuditLog
    {
        public int StudentId { get; set; } // Primary Key
        public string StudentName { get; set; }
        public string Action { get; set; }
        public DateTime VerificationTimestamp { get; set; } // Timestamp
    }


}
