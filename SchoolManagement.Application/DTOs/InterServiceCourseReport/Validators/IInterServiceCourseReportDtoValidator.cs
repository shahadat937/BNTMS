using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseReport.Validators
{
    public class IInterServiceCourseReportDtoValidator : AbstractValidator<IInterServiceCourseReportDto>
    {
        public IInterServiceCourseReportDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
