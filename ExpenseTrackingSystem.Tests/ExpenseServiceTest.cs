using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Models.Expenses;
using ExpenseTrackingSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ExpenseTrackingSystem.Tests
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void AddExpense_ShouldCategorize_TravelExpense()
        {
            var _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var options = new DbContextOptionsBuilder<ExpenseTrackerDB>()
                .UseSqlServer(_configuration.GetConnectionString("ExpenseContext"))
                .Options;
            var dbContext = new ExpenseTrackerDB(options);

            
            // Arrange
            var expenseTypeService = new ExpenseTypeService(dbContext);
            var expenseService = new ExpenseService(dbContext);
            var dto = new CreateExpenseDto { 
                Amount = 125.00m,
                Description = "Milk 1 Ltr.",
                Date = DateTime.Now,
                ExpenseType = "Food"
            };

            var userService = new UserService(dbContext);
            var validUser = userService.GetUsers().Data.FirstOrDefault();

            if(validUser == null)
                Assert.Fail("No valid user found for testing.");

            // Act
            expenseService.CreateExpense(dto, validUser.Id);
            var categorizedExpense = expenseTypeService.GetExpenseTypes().Data.FirstOrDefault(d => d.Name == dto.ExpenseType);
            // Assert
            Assert.Equal(dto.ExpenseType, categorizedExpense?.Name);
        }
    }
}
