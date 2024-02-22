using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiometricsAPI.Models
{
    public class Biousers
    {
        [Required]
        [Key]
        public string UserId { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [StringLength(4)] // Assuming PIN is 4 characters long
        [RegularExpression("^[0-9]*$")] // PIN should only contain digits
       
        public string Pin { get; set; }

        [Required]
        [StringLength(10)] // Assuming contact number is 10 digits long
        [RegularExpression("^[0-9]*$")] // Contact should only contain digits
        public string Contact { get; set; }

        [Required]
        public Permissions Permissions { get; set; } // Modify to match frontend

        // Constructor, getters, setters, etc.
    }
}
