using BiometricsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BiometricsAPI.Models;

namespace BiometricsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VerificationController : ControllerBase
    {
        private readonly VerificationService _verificationService;

        public VerificationController(VerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [HttpPost]
        public IActionResult VerifyFingerprint([FromBody] byte[] fingerprint)
        {
            var student = _verificationService.VerifyFingerprint(fingerprint);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound("Student not found");
            }
        }
    }
}
