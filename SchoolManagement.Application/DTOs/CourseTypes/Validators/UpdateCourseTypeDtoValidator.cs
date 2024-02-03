using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.CourseTypes.Validators
{
    public class UpdateCourseTypeDtoValidator : AbstractValidator<CourseTypeDto>
    {
        public UpdateCourseTypeDtoValidator()
        {
            Include(new ICourseTypeDtoValidator());

            RuleFor(b => b.CourseTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

