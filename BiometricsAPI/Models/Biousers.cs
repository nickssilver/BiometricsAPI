using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BiometricsAPI.Models
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Page1 = 1,
        Page2 = 2,
        Page3 = 4,
        Page4 = 8
        // Add more permissions as needed
    }

    [Index(nameof(UserId), IsUnique = true)]
    [Index(nameof(Pin), IsUnique = true)]
    public class Biousers
    {
        [Key]
        public string UserId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Department { get; set; }
        public string Pin { get; set; }
        public string Contact { get; set; }
        public Permissions Permissions { get; set; }
    }
}
