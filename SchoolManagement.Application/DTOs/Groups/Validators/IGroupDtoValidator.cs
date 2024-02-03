using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Groups.Validators
{ 
    public class IGroupDtoValidator : AbstractValidator<IGroupDto>
    {
        public IGroupDtoValidator()
        {
            RuleFor(p => p.GroupName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
