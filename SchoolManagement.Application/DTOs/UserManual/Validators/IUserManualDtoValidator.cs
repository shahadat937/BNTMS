using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UserManual.Validators
{
    public class IUserManualDtoValidator : AbstractValidator<IUserManualDto>
    {
        public IUserManualDtoValidator()
        {
            RuleFor(c => c.RoleName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
