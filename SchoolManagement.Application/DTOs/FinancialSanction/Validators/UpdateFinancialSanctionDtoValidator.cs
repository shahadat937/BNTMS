using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FinancialSanction.Validators
{
    public class UpdateFinancialSanctionDtoValidator : AbstractValidator<FinancialSanctionDto>
    {
        public UpdateFinancialSanctionDtoValidator()
        {
            Include(new IFinancialSanctionDtoValidator());

            RuleFor(b => b.FinancialSanctionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

