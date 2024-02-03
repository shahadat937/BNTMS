using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.CourseModule.Validators
{
    public class UpdateCourseModuleDtoValidator : AbstractValidator<CourseModuleDto>
    {
        public UpdateCourseModuleDtoValidator()
        {
            Include(new ICourseModuleDtoValidator());

            RuleFor(p => p.BaseSchoolNameId).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.CourseNameId).NotNull().WithMessage("{PropertyName} must be present");
           

        }
    }
}
