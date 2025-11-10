namespace ExpenseTrackingSystem.Models.Users
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserResponseModel
    {
        public string Email { get; set; } = string.Empty;
    }

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
