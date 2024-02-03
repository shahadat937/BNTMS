using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetType.Validators
{
    public class CreateBudgetTypeDtoValidator : AbstractValidator<CreateBudgetTypeDto>
    {
        public CreateBudgetTypeDtoValidator()
        {
            Include(new IBudgetTypeDtoValidator());
        }
    }
}
