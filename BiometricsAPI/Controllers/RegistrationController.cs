using BiometricsAPI.Models;
using BiometricsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> RegisterStudent([FromBody] BiometricModel registrationData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
            }

            var model = new BiometricModel
            {
                StudentId = registrationData.StudentId,
                StudentName = registrationData.StudentName,
                ClassId = registrationData.ClassId,
                Status = registrationData.Status,
                Arrears = registrationData.Arrears,
                Fingerprint1 = registrationData.Fingerprint1,
                Fingerprint2 = registrationData.Fingerprint2
            };

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
