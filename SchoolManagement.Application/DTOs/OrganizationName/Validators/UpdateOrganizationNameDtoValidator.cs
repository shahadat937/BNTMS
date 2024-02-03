using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OrganizationName.Validators
{
    public class UpdateOrganizationNameDtoValidator : AbstractValidator<OrganizationNameDto>
    {
        public UpdateOrganizationNameDtoValidator()
        {
            Include(new IOrganizationNameDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
