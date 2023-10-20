using System;
using System.ComponentModel.DataAnnotations;

namespace BiometricsAPI.Models
{
    public class RegistrationRequestModel
    {
        [Required]
        public int StudentNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string Class { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public decimal Arrears { get; set; }
        public byte[] Fingerprint1 { get; set; }
        public byte[] Fingerprint2 { get; set; }
    }
}
