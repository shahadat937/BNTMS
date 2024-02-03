using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Occupation.Validators
{
    public class IOccupationDtoValidator : AbstractValidator<IOccupationDto>
    {
        public IOccupationDtoValidator()
        {
            RuleFor(c => c.OccupationName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
