
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseGradingEntry.Validators
{
   public class CreateCourseGradingEntryDtoValidator : AbstractValidator<CreateCourseGradingEntryDto>
    {
        public CreateCourseGradingEntryDtoValidator()
        {
            Include(new ICourseGradingEntryDtoValidator());
        }
    }
}
