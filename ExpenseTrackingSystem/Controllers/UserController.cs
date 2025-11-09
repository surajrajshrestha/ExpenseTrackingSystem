using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Users;
using ExpenseTrackingSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserService _userService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(
            UserService userService, 
            IPasswordHasher<User> passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }


        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUser(UserDto model)
        {
            var response = _userService.CreateUser(model);
            return StatusCode(response.StatusCode, response);
        }
    }
}
