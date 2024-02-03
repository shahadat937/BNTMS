using FluentValidation;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoCurricularActivityType.Validators
{
    public class ICoCurricularActivityTypeDtoValidator : AbstractValidator<ICoCurricularActivityTypeDto>
    {
        public ICoCurricularActivityTypeDtoValidator()
        {
            RuleFor(p => p.CoCurricularActivityName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
