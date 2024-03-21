using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BnaClassPeriod.Validators
{
    public class IBnaClassPeriodDtoValidator : AbstractValidator<IBnaClassPeriod>
    {
        public IBnaClassPeriodDtoValidator()
        {
            RuleFor(b => b.BnaClassPeriodName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
