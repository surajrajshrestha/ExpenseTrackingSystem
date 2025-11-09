namespace ExpenseTrackingSystem.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string ExpenseType { get; set; } = string.Empty;

        public DateTime CreatedOnUtc { get; set; }
    }
}
