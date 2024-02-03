using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BloodGroup.Validators
{
    public class CreateBloodGroupDtoValidator : AbstractValidator<CreateBloodGroupDto>
    {
        public CreateBloodGroupDtoValidator()
        {
            Include(new IBloodGroupDtoValidator());
        }
    }
}
