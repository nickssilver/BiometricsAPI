using BiometricsAPI.Models;
using BiometricsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Biousers user)
        {
            if (ModelState.IsValid)
            {
                // Extract permissions from the user object
                var selectedPermissions = new List<bool>
                {
                    user.RegisterPermission,
                    user.VerifyPermission,
                    user.RefactorPermission,
                    user.AnalyticsPermission,
                    user.ManagementPermission
                };

                // Perform any necessary validation

                // Save the user entity to the database
                var registeredUser = await _userService.RegisterUserAsync(user, selectedPermissions);
                if (registeredUser != null)
                {
                    return Ok(registeredUser);
                }
                else
                {
                    return BadRequest(new { message = "User could not be registered" });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string pin)
        {
            var user = await _userService.AuthenticateUserAsync(pin);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid pin" });
            }

            // Return the UserId along with permissions
            return Ok(new
            {
                UserId = user.UserId,
                user.RegisterPermission,
                user.VerifyPermission,
                user.RefactorPermission,
                user.AnalyticsPermission,
                user.ManagementPermission
            });
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(user);
        }
    }
}
