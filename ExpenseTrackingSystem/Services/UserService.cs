using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Responses;
using ExpenseTrackingSystem.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTrackingSystem.Services
{
    public class UserService
    {
        private readonly ExpenseTrackerDB _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(ExpenseTrackerDB context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public ResponseModel<UserResponseModel> CreateUser(UserDto model)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == model.Email);

            if (existingUser == null)
            {
                existingUser = new User { Email = model.Email };
                existingUser.Password = _passwordHasher.HashPassword(existingUser, model.Password);
                _context.Users.Add(existingUser);
                _context.SaveChanges();

                return new ResponseModel<UserResponseModel>
                {
                    StatusCode = StatusCodes.Status201Created,
                    Messages = ["User registered successfully."],
                    Data = new UserResponseModel {
                        Email = existingUser.Email
                    }
                };
            }

            return new ResponseModel<UserResponseModel>
            {
                StatusCode = StatusCodes.Status409Conflict,
                Messages = ["User with this email already exists."],
                Data = new UserResponseModel { 
                    Email = existingUser.Email
                }
            };
        }
    }
}
