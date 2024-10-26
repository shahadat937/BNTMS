using FluentValidation;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BudgetTransaction.Validators
{
    public class UpdateBudgetTransactionDtoValidator:AbstractValidator<BudgetTransactionDto>
    {
       public UpdateBudgetTransactionDtoValidator()
        {
            Include(new IBudgetTransactionDtoValidator());
            RuleFor(p => p.BudgetTransactionId).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
