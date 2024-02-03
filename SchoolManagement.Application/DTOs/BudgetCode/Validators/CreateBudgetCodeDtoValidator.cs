using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetCode.Validators
{
    public class CreateBudgetCodeDtoValidator : AbstractValidator<CreateBudgetCodeDto>
    {
        public CreateBudgetCodeDtoValidator()
        {
            Include(new IBudgetCodeDtoValidator());
        }
    }
}
