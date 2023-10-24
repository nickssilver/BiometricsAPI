using System.ComponentModel.DataAnnotations;

namespace BiometricsAPI.Models
{
    public class Biometric
    {
        
        [Required]
        public int StudentId { get; set; } // Primary Key
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal Arrears { get; set; }
        [Required]  
        public byte[] Fingerprint1 { get; set; } // Binary data for the first fingerprint scan
        [Required]
        public byte[] Fingerprint2 { get; set; } // Binary data for the second fingerprint scan
    }

}
