using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DefenseType.Validators
{
    public class IDefenseTypeDtoValidator : AbstractValidator<IDefenseTypeDto>
    {
        public IDefenseTypeDtoValidator()
        {
            RuleFor(c => c.DefenseTypeName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
