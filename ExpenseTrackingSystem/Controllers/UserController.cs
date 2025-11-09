using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ExpenseTrackerDB _context;

        public UserController(ExpenseTrackerDB context)
        {
            _context = context;
        }


        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto model)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (existingUser == null)
            {
                existingUser = new User { Email = model.Email, Password = model.Password };
                _context.Users.Add(existingUser);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUser", new { id = existingUser.Id }, existingUser);
            }
            
            return Conflict("User with this email already exists.");
        }
    }
}
