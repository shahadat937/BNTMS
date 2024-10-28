using FluentValidation;
using System;
using System.Linq;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetTransaction.Validators
{
    public class IBudgetTransactionDtoValidator:AbstractValidator<IBudgetTransactionDto>
    {
        public IBudgetTransactionDtoValidator()
        {

        }
    }
}
