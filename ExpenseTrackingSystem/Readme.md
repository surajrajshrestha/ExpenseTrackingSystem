# Expense Tracking System
- Users
- Expenses
- ExpenseTypes
- ExpenseReportItem 

# ExpenseType(Name)
- Expense Type is unique as it defines the category of expense such as Food, Transport, Utilities, etc.

# Expenses(Id, ExpenseType, Amount, Date, UserId, CreatedDate)
- AddExpense(UserId, ExpenseType, Amount, Date)

# ExpenseReportItem(ExpenseDate, ExpenseType, Amount, Description)
- Total monthly expenses based on User

# Features
- Login
- Register User
- Add Expense
- Add Expense Type
- Generate Monthly Expense Report
