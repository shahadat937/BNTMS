using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.ClassRoutine.Validators
{
    public class UpdateClassRoutineDtoValidator : AbstractValidator<CreateClassRoutineDto>
    {
        public UpdateClassRoutineDtoValidator()
        {
            Include(new IClassRoutineDtoValidator());

            //RuleFor(p => p.ClassPeriodId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSubjectNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BaseSchoolNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.ClassTypeId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.CourseDurationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
