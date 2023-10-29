using BiometricsAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult VerifyFingerprint([FromBody] string fingerprint)
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
