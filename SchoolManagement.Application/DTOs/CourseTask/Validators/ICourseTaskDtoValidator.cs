using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseTask.Validators
{
    public class ICourseTaskDtoValidator : AbstractValidator<ICourseTaskDto>
    {
        public ICourseTaskDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
