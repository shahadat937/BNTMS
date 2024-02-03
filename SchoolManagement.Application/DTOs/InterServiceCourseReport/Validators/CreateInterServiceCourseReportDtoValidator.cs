
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseReport.Validators
{
   public class CreateInterServiceCourseReportDtoValidator : AbstractValidator<CreateInterServiceCourseReportDto>
    {
        public CreateInterServiceCourseReportDtoValidator()
        {
            Include(new IInterServiceCourseReportDtoValidator());
        }
    }
}
