using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignTrainingCourseReport.Validators
{
    public class UpdateForeignTrainingCourseReportDtoValidator : AbstractValidator<ForeignTrainingCourseReportDto>
    {
        public UpdateForeignTrainingCourseReportDtoValidator()
        {
            Include(new IForeignTrainingCourseReportDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
