using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Login;
using ExpenseTrackingSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ExpenseTrackerDB _context;
        private readonly JwtService _jwtService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(
            ExpenseTrackerDB context,
            JwtService jwtService,
            IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Success)
            {
                var token = _jwtService.GenerateToken(user);

                return Ok(new { Token = token });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = "Either username or password is invalid" });
            }
            
        }
    }
}
