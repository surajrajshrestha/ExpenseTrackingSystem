using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("expenses")]
    [ApiController]
    public class ExpenseController : BaseController
    {
        private readonly ExpenseTrackerDB _context;

        public ExpenseController(ExpenseTrackerDB context)
        {
            _context = context;
        }

        // POST: api/Expense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(CreateExpenseDto model)
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                UserId = GetLoggedInUser(),
                Amount = model.Amount,
                Description = model.Description,
                Date = model.Date,
                ExpenseType = model.ExpenseType,
                CreatedOnUtc = DateTime.UtcNow
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }
    }
}
