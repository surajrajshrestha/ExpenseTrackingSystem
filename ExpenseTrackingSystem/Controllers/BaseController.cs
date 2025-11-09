using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExpenseTrackingSystem.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {

        [HttpGet("GetLoggedInUser")]
        public Guid GetLoggedInUser() {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            return Guid.Parse(userId ?? Guid.Empty.ToString());
        }
    }
}
