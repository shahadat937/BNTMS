
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignTrainingCourseReport.Validators
{
   public class CreateForeignTrainingCourseReportDtoValidator : AbstractValidator<CreateForeignTrainingCourseReportDto>
    {
        public CreateForeignTrainingCourseReportDtoValidator()
        {
            Include(new IForeignTrainingCourseReportDtoValidator());
        }
    }
}
