using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AdminAuthority.Validators
{
    public class IAdminAuthorityDtoValidator : AbstractValidator<IAdminAuthorityDto>
    {
        public IAdminAuthorityDtoValidator()
        { 
            RuleFor(c => c.AdminAuthorityName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
