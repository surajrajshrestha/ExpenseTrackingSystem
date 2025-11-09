using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Login;
using ExpenseTrackingSystem.Models.Responses;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTrackingSystem.Services
{
    public class AuthenticationService
    {
        private readonly ExpenseTrackerDB _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;

        public AuthenticationService(
            ExpenseTrackerDB context,
            IPasswordHasher<User> passwordHasher,
            JwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public ResponseModel<string> Login(LoginRequest request)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return new ResponseModel<string>()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Messages = ["Either username or password is invalid."],
                    Data = ""
                };
            }

            try
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    var token = _jwtService.GenerateToken(user);
                    return new ResponseModel<string>()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["User authentication successful."],
                        Data = token
                    };
                }
                else
                {
                    return new ResponseModel<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Either username or password is invalid."],
                        Data = "Unable to generate token."
                    };
                }
            }
            catch (FormatException)
            {

                if (user.Password == request.Password)
                {
                    return new ResponseModel<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Update your password before login."],
                        Data = "Unable to generate token."
                    };
                }
                else
                {
                    return new ResponseModel<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Either username or password is invalid."],
                        Data = ""
                    };
                }
            }


        }
    }
}
