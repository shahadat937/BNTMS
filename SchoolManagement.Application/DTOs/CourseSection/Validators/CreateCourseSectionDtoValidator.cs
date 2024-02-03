using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseSection.Validators
{
    public class CreateCourseSectionDtoValidator : AbstractValidator<CreateCourseSectionDto>
    {
        public CreateCourseSectionDtoValidator()
        {
            Include(new ICourseSectionDtoValidator());
        }
    }
}
