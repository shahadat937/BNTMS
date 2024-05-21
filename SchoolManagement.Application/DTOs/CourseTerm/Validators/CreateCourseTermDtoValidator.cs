using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseTerm.Validators
{
    public class CreateCourseTermDtoValidator : AbstractValidator<CreateCourseTermDto>
    {
        public CreateCourseTermDtoValidator()
        {
            Include(new ICourseTermDtoValidator());
        }
    }
}
