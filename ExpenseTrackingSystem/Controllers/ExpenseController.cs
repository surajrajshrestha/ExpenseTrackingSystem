using ExpenseTrackingSystem.Models.Expenses;
using ExpenseTrackingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("expenses")]
    [ApiController]
    public class ExpenseController : BaseController
    {
        private readonly ExpenseService _service;

        public ExpenseController(ExpenseService service)
        {
            _service = service;
        }


        // POST: api/Expense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Create(CreateExpenseDto model)
        {
            var expense = _service.CreateExpense(model, GetLoggedInUser());

            return StatusCode(StatusCodes.Status201Created, new { expense });
        }
    }
}
