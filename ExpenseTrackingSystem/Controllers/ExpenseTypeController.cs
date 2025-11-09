using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
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

        // GET: api/ExpenseType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseType>> GetExpenseType(string id)
        {
            var expenseType = await _context.ExpenseTypes.FindAsync(id);

            if (expenseType == null)
            {
                return NotFound();
            }

            return expenseType;
        }

        // PUT: api/ExpenseType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseType(string id, ExpenseType expenseType)
        {
            if (id != expenseType.Name)
            {
                return BadRequest();
            }

            _context.Entry(expenseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseTypeExists(id))
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

        // POST: api/ExpenseType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenseType>> PostExpenseType(ExpenseType expenseType)
        {
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

        // DELETE: api/ExpenseType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseType(string id)
        {
            var expenseType = await _context.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }

            _context.ExpenseTypes.Remove(expenseType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseTypeExists(string id)
        {
            return _context.ExpenseTypes.Any(e => e.Name == id);
        }
    }
}
