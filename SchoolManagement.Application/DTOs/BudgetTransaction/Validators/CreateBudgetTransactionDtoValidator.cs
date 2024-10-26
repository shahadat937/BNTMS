using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SchoolManagement.Application.DTOs.BudgetTransaction.Validators
{
    public class CreateBudgetTransactionDtoValidator: AbstractValidator<CreateBudgetTransactionDto>
    {
        public CreateBudgetTransactionDtoValidator() { 
            Include(new IBudgetTransactionDtoValidator());
        }
    }
}
