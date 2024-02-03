using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseReport.Validators
{
    public class UpdateInterServiceCourseReportDtoValidator : AbstractValidator<InterServiceCourseReportDto>
    {
        public UpdateInterServiceCourseReportDtoValidator()
        {
            Include(new IInterServiceCourseReportDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
