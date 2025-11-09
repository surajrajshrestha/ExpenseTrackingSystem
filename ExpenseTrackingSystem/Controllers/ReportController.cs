using ExpenseTrackingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackingSystem.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly ExpenseTrackerDB _context;

        public ReportController(ExpenseTrackerDB context)
        {
            _context = context;
        }

        /// <summary>
        /// This will generates expense report for a user provided the year, month and expense type.
        /// </summary>
        /// <param name="userId">The report to be generated for</param>
        /// <param name="year">
        ///     The year for which the report is to be generated. 
        ///     If year is null
        ///         default: current year
        /// </param>
        /// <param name="month">
        ///     The month for which the report is to be generated. 
        ///     If month is null 
        ///         default: current month
        ///     If month is 0 or greater than 12
        ///         default: current month
        /// </param>
        /// <param name="expenseType">
        ///     The type of expense for which the report is to be generated for. 
        ///     If expenseType is null
        ///         default: ''
        /// </param>
        /// <returns>A list of expenses for the given year month</returns>
        [HttpGet("getMonthlyExpense")]
        public IActionResult GetMonthlyExpense(Guid userId, int? year, int? month, string? expenseType)
        {
            var UserIdParam = new SqlParameter("@UserId", userId);
            var YearParam = new SqlParameter("@Year", (object?)year ?? DBNull.Value);
            var MonthParam = new SqlParameter("@Month", (object?)month ?? DBNull.Value);
            var ExpenseTypeParam = new SqlParameter("@ExpenseType", (object?)expenseType ?? string.Empty);

            var response = _context.ExpenseReportItems.FromSqlRaw(
                "EXEC sp_GetMonthlyExpenseOfUser @UserId, @Year, @Month, @ExpenseType",
                parameters: [UserIdParam, YearParam, MonthParam, ExpenseTypeParam]);

            return Ok(response);
        }
    }
}
