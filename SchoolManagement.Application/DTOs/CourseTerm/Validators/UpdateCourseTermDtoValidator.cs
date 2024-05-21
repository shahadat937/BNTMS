using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseTerm.Validators
{
    
    public class UpdateCourseTermDtoValidator : AbstractValidator<CourseTermDto>
        {
        public UpdateCourseTermDtoValidator()
        {
            Include(new ICourseTermDtoValidator()); 

            RuleFor(p => p.CourseTermId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
