using Microsoft.Identity.Client;

namespace ExpenseTrackingSystem.Entities.ReportItems
{
    public class ExpenseReportItem
    {
        public DateTime ExpenseDate { get; set; }
        public string ExpenseType { get; set; } = string.Empty;
        public decimal Amount { get; set; } 
        public string? Description { get; set; }
    }
}
