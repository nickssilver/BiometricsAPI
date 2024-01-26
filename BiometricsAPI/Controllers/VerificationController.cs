using BiometricsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            byte[] fingerprintBytes = Convert.FromBase64String(fingerprint);
            var student = _verificationService.VerifyFingerprint(fingerprintBytes);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound("Student not found");
            }
        }

        [HttpGet("GetAllFingerprintTemplates")]
        public IActionResult GetAllFingerprintTemplates()
        {
            try
            {
                var students = _verificationService.GetAllFingerprintTemplates();
                if (students != null)
                {
                    return Ok(students);
                }
                else
                {
                    return BadRequest("An error occurred while trying to retrieve the templates.");
                }
            }
            catch (Exception)
            {
                return BadRequest("An error occurred while trying to retrieve the templates.");
            }
        }



    }
}