using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CourseModule.Validators
{
    public class ICourseModuleDtoValidator : AbstractValidator<ICourseModuleDto>
    {
        public ICourseModuleDtoValidator()
        {
            

            RuleFor(p => p.BaseSchoolNameId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            RuleFor(p => p.CourseNameId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            
            

        }
    }
}
