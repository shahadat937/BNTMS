
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OrganizationName.Validators
{
   public class CreateOrganizationNameDtoValidator : AbstractValidator<CreateOrganizationNameDto>
    {
        public CreateOrganizationNameDtoValidator()
        {
            Include(new IOrganizationNameDtoValidator());
        }
    }
}
