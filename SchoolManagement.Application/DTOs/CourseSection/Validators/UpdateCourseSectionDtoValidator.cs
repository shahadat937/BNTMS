using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.CourseSection.Validators
{
    public class UpdateCourseSectionDtoValidator : AbstractValidator<CourseSectionDto>
    {
        public UpdateCourseSectionDtoValidator()
        {
            Include(new ICourseSectionDtoValidator());

            RuleFor(p => p.BaseSchoolNameId).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.CourseNameId).NotNull().WithMessage("{PropertyName} must be present");
           

        }
    }
}
