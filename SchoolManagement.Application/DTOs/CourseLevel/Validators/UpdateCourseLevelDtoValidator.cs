using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseLevel.Validators
{
    
    public class UpdateCourseLevelDtoValidator : AbstractValidator<CourseLevelDto>
        {
        public UpdateCourseLevelDtoValidator()
        {
            Include(new ICourseLevelDtoValidator()); 

            RuleFor(p => p.CourseLevelId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
