using System.ComponentModel.DataAnnotations;

namespace BiometricsAPI.Models
{
    public class AdminUser
    {

        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
