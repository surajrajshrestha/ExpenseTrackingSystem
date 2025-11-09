using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Expenses;
using ExpenseTrackingSystem.Models.Responses;

namespace ExpenseTrackingSystem.Services
{
    public class ExpenseService(ExpenseTrackerDB context)
    {

        public ResponseModel<Expense> CreateExpense(CreateExpenseDto model, Guid userId)
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Amount = model.Amount,
                Description = model.Description,
                Date = model.Date,
                ExpenseType = model.ExpenseType,
                CreatedOnUtc = DateTime.UtcNow
            };

            context.Expenses.Add(expense);
            context.SaveChanges();

            return new ResponseModel<Expense> { 
                StatusCode = StatusCodes.Status201Created,
                Messages = ["Expense created successfully."],
                Data = expense
            };
        }
    }
}
