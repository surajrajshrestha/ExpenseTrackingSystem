using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.ExpenseTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("expense-types")]
    [ApiController]
    public class ExpenseTypeController : BaseController
    {
        private readonly ExpenseTrackerDB _context;

        public ExpenseTypeController(ExpenseTrackerDB context)
        {
            _context = context;
        }

        // GET: api/ExpenseType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseType>>> GetExpenseTypes()
        {
            return await _context.ExpenseTypes.ToListAsync();
        }

        // POST: api/ExpenseType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenseType>> PostExpenseType(CreateExpenseTypeDto model)    
        {
            var expenseType = new ExpenseType
            {
                Name = model.ExpenseType
            };
            _context.ExpenseTypes.Add(expenseType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExpenseTypeExists(expenseType.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExpenseType", new { id = expenseType.Name }, expenseType);
        }

        private bool ExpenseTypeExists(string id)
        {
            return _context.ExpenseTypes.Any(e => e.Name == id);
        }
    }
}
