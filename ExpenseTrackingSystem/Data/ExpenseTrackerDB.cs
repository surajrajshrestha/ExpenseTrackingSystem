using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Entities.ReportItems;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackingSystem.Data
{
    public class ExpenseTrackerDB : DbContext
    {
        public ExpenseTrackerDB(DbContextOptions<ExpenseTrackerDB> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseReportItem> ExpenseReportItems { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExpenseType>().HasKey(p => p.Name);

            modelBuilder.Entity<ExpenseReportItem>(eb =>
            {
                eb.HasNoKey();
                eb.ToView(null);
            });
        }
    }
}
