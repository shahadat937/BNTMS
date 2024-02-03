using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ClassRoutine.Validators
{
    public class IClassRoutineDtoValidator : AbstractValidator<IClassRoutineDto>
    {
        public IClassRoutineDtoValidator()
        {
            

            //RuleFor(p => p.ClassPeriodId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.BaseSchoolNameId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.CourseDurationId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.BnaSubjectNameId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
           
            //RuleFor(p => p.ClassTypeId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

            //RuleFor(p => p.AdditionalInformation)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            

        }
    }
}
