using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaInstructorType.Validators
{
    public class CreateBnaInstructorTypeDtoValidator : AbstractValidator<CreateBnaInstructorTypeDto>
    {
        public CreateBnaInstructorTypeDtoValidator()
        {
            Include(new IBnaInstructorTypeDtoValidator());
        }
    }
}
 