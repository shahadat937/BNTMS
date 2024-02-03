using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseName.Validators
{
    public class CreateCourseNameDtoValidator : AbstractValidator<CreateCourseNameDto>
    {
        public CreateCourseNameDtoValidator()
        {
            Include(new ICourseNameDtoValidator());
        }
    }
}
