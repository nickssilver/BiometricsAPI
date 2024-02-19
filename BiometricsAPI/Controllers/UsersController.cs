using BiometricsAPI.Services;
using BiometricsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = await _userService.RegisterUserAsync(model.User, model.Permissions);
            if (user == null)
            {
                return BadRequest(new { message = "User could not be registered" });
            }
            return Ok(user);
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
            return Ok(user);
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

    public class RegisterViewModel
    {
        public Biousers User { get; set; }
        public List<Permissions> Permissions { get; set; }
    }
}
