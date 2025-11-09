namespace ExpenseTrackingSystem.Models.Expenses
{
    public class CreateExpenseDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ExpenseType { get; set; } = string.Empty;
    }
}
