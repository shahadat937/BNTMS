using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Nationality.Validators
{
    public class INationalityDtoValidator : AbstractValidator<INationalityDto>
    {
        public INationalityDtoValidator()
        {
            RuleFor(b => b.NationalityName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
