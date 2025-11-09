using ExpenseTrackingSystem.Data;
using ExpenseTrackingSystem.Entities;
using ExpenseTrackingSystem.Models.ExpenseTypes;
using ExpenseTrackingSystem.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackingSystem.Services
{
    public class ExpenseTypeService(ExpenseTrackerDB context)
    {
        public ResponseModel<List<ExpenseType>> GetExpenseTypes()
        {
            var expenseTypes = context.ExpenseTypes.ToList();
            return new ResponseModel<List<ExpenseType>> {
                StatusCode = StatusCodes.Status200OK,
                Messages = ["Data fetched successfully"],
                Data = expenseTypes
            };
        }

        public ResponseModel<ExpenseType> CreateExpenseType(CreateExpenseTypeDto model)
        {
            var expenseType = new ExpenseType
            {
                Name = model.ExpenseType
            };
            context.Add(expenseType);
            try
            {
                context.SaveChanges();
                return new ResponseModel<ExpenseType> { 
                    StatusCode = StatusCodes.Status201Created,
                    Messages = ["Expense type created successfully."],
                    Data = expenseType
                };
            }
            catch (DbUpdateException e)
            {
                if (ExpenseTypeExists(expenseType.Name))
                {
                    return new ResponseModel<ExpenseType>
                    {
                        StatusCode = StatusCodes.Status409Conflict,
                        Messages = ["Expense type already exists."],
                        Data = null!
                    };
                }
                else
                {
                    return new ResponseModel<ExpenseType>
                    {
                        StatusCode = StatusCodes.Status409Conflict,
                        Messages = [e.Message],
                        Data = null!
                    };
                }
            }

        }

        private bool ExpenseTypeExists(string id)
        {
            return context.ExpenseTypes.Any(e => e.Name == id);
        }
    }
}
