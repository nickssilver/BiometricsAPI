using BiometricsAPI.Data;
using BiometricsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BiometricsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminAuthController : ControllerBase
    {
        private readonly BiometricsContext _context;

        public AdminAuthController(BiometricsContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminUser adminUser)
        {
            var user = await _context.AdminUsers.FirstOrDefaultAsync(u => u.Username == adminUser.Username);

            if (user == null || user.Password != adminUser.Password)
                return Unauthorized(new { message = "Invalid username or password" });

            // Authentication successful
            return Ok(new { message = "Authentication successful" });
        }
    }
}
