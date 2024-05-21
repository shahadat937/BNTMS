using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseLevel.Validators
{
    public class CreateCourseLevelDtoValidator : AbstractValidator<CreateCourseLevelDto>
    {
        public CreateCourseLevelDtoValidator()
        {
            Include(new ICourseLevelDtoValidator());
        }
    }
}
