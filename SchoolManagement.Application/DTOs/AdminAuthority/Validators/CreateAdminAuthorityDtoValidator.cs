
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AdminAuthority.Validators
{
   public class CreateAdminAuthorityDtoValidator : AbstractValidator<CreateAdminAuthorityDto>
    {
        public CreateAdminAuthorityDtoValidator()
        {
            Include(new IAdminAuthorityDtoValidator());
        }
    }
}
