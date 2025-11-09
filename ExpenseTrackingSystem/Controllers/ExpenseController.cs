using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.Expenses;

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

        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(Guid id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/Expense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(Guid id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(Guid id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
