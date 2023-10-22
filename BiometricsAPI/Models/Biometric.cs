namespace BiometricsAPI.Models
{
    public class Biometric
    {
        public int StudentId { get; set; } // Primary Key
        public string StudentName { get; set; }
        public string Class { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public decimal Arrears { get; set; }
        public byte[] Fingerprint1 { get; set; } // Binary data for the first fingerprint scan
        public byte[] Fingerprint2 { get; set; } // Binary data for the second fingerprint scan
    }

}
