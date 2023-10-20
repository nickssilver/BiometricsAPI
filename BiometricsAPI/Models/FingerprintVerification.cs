using System.ComponentModel.DataAnnotations;

namespace BiometricsAPI.Models
{
    public class FingerprintVerificationModel
    {
        
        public int StudentNumber { get; set; }

        [Required]
        public byte[] ScannedFingerprint { get; set; }
    }
}
