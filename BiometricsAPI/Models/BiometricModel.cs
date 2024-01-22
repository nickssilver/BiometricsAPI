using System.ComponentModel.DataAnnotations;

public class BiometricModel
{
    [Required]
    public string StudentId { get; set; } // Primary Key
    [Required]
    public string StudentName { get; set; }
    [Required]
    public string ClassId { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public decimal Arrears { get; set; }
    [Required]
    public byte[] Fingerprint1 { get; set; } // Binary data representation of the first fingerprint
    [Required]
    public byte[] Fingerprint2 { get; set; } // Binary data representation of the second fingerprint

    // ...
}
