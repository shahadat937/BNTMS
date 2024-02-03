using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseName.Validators
{
    
    public class UpdateCourseNameDtoValidator : AbstractValidator<CreateCourseNameDto>
        {
        public UpdateCourseNameDtoValidator()
        {
            Include(new ICourseNameDtoValidator());

            //RuleFor(p => p.CourseNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
