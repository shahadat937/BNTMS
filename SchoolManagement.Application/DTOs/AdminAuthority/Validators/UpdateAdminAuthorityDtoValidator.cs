using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AdminAuthority.Validators
{
    public class UpdateAdminAuthorityDtoValidator : AbstractValidator<AdminAuthorityDto>
    {
        public UpdateAdminAuthorityDtoValidator()
        { 
            Include(new IAdminAuthorityDtoValidator());

            RuleFor(c => c.AdminAuthorityId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
