using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignTrainingCourseReport.Validators
{
    public class IForeignTrainingCourseReportDtoValidator : AbstractValidator<IForeignTrainingCourseReportDto>
    {
        public IForeignTrainingCourseReportDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
