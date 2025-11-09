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

        public ResponseModel<string> ChangePassword(ChangePasswordRequest request)
        {
            if(!string.Equals(request.NewPassword, request.ConfirmPassword))
            {
                return new ResponseModel<string>()
                {
                    StatusCode = StatusCodes.Status412PreconditionFailed,
                    Messages = ["New Password and Confirm Password does not match."],
                    Data = "New Password and Confirm Password does not match."
                };
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return new ResponseModel<string>()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Messages = ["User with the email was not found."],
                    Data = ""
                };
            }

            try
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.CurrentPassword);
                if (result == PasswordVerificationResult.Success)
                {
                    user.Password = _passwordHasher.HashPassword(user, request.NewPassword);
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    var token = _jwtService.GenerateToken(user);
                    return new ResponseModel<string>()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Password changed successfully."],
                        Data = token
                    };
                }
                else
                {
                    return new ResponseModel<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Old password and Current Password does not match."],
                        Data = "Old password and Current Password does not match."
                    };
                }
            }
            catch (FormatException)
            {

                if (user.Password == request.CurrentPassword)
                {
                    user.Password = _passwordHasher.HashPassword(user, request.NewPassword);
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    var token = _jwtService.GenerateToken(user);

                    return new ResponseModel<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Password changed successfully."],
                        Data = token
                    };
                }
                else
                {
                    return new ResponseModel<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Messages = ["Old password and Current Password does not match."],
                        Data = "Unable to change password."
                    };
                }
            }
        }
    }
}
