using BiometricsAPI.Models;
using BiometricsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiometricsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiometricsController : ControllerBase
    {
        private readonly BiometricsService _biometricsService;

        public BiometricsController(BiometricsService biometricsService)
        {
            _biometricsService = biometricsService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegistrationRequestModel model)
        {
            try
            {
                // Validate the student details here, e.g., check if the student exists in the "Register" table.
                if (!_biometricsService.StudentExistsInRegisterTable(model.StudentNumber))
                {
                    return BadRequest("Student not found in the Register table.");
                }

                // Assuming a model for storing user details and fingerprints
                var userData = new UserData
                {
                    StudentNumber = model.StudentNumber,
                    StudentName = model.StudentName,
                    // Other properties like Class, Department, Status, Arrears, Fingerprint1, Fingerprint2
                };

                // Save the user data to the "Biometrics" table using Entity Framework Core.
                _biometricsService.RegisterUser(userData);

                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response if necessary.
                return StatusCode(500, "An error occurred while processing the registration.");
            }
        }

        [HttpPost("verify")]
        public IActionResult VerifyUser([FromBody] FingerprintVerificationModel model)
        {
            try
            {
                // Match the scanned fingerprint with data from the "Biometrics" table.
                var matchedUser = _biometricsService.VerifyUser(model);

                if (matchedUser == null)
                {
                    // Log the failed verification in the "AuditLog" table.
                    _biometricsService.LogFailedVerification(model.StudentNumber);

                    return BadRequest("Verification failed. Student not found or fingerprints do not match.");
                }

                // Log the successful verification in the "AuditLog" table.
                _biometricsService.LogSuccessfulVerification(model.StudentNumber);

                // Return the student details to the user.
                return Ok(matchedUser);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response if necessary.
                return StatusCode(500, "An error occurred while processing the verification.");
            }
        }
    }
}
