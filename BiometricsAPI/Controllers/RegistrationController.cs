using BiometricsAPI.Models;
using BiometricsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace BiometricsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent([FromBody] Biometric model)
        {
            var result = await _registrationService.RegisterStudent(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration failed");
            }
        }
    }
}
