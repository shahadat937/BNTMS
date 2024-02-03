using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OrganizationName.Validators
{
    public class IOrganizationNameDtoValidator : AbstractValidator<IOrganizationNameDto>
    {
        public IOrganizationNameDtoValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
