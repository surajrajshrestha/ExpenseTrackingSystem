using ExpenseTrackingSystem.Models.ExpenseTypes;
using ExpenseTrackingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("expense-types")]
    [ApiController]
    public class ExpenseTypeController : BaseController
    {
        private readonly ExpenseTypeService _service;

        public ExpenseTypeController(ExpenseTypeService service)
        {
            _service = service;
        }

        // GET: api/ExpenseType
        [HttpGet]
        public IActionResult GetExpenseTypes()
        {
            return Ok(_service.GetExpenseTypes());
        }

        // POST: api/ExpenseType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateExpenseType(CreateExpenseTypeDto model)
        {
            var expenseType = _service.CreateExpenseType(model);
            if (expenseType.StatusCode == StatusCodes.Status201Created)
            {
                return StatusCode(StatusCodes.Status201Created, new { expenseType });
            }
            return StatusCode(expenseType.StatusCode, expenseType);
        }
    }
}
