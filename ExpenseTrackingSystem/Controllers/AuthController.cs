using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Models.Login;
using ExpenseTrackingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ExpenseTrackerDB _context;
        private readonly JwtService _jwtService;

        public AuthController(
            ExpenseTrackerDB context, 
            JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
