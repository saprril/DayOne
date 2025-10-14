using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StatePattern.Models;
using StatePattern.Services;
using StatePattern.DTOs;

namespace StatePattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<User> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new { message = "Invalid username or password" });

            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            // Check if username already exists
            var existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
                return BadRequest(new { message = "Username already exists." });

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Role = "User" // default role
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Generate JWT token immediately after registration
            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new { token });
        }

    }
}
