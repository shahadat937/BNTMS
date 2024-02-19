using FluentValidation;
using SchoolManagement.Application.DTOs.CourseWeeks.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.CourseWeekAll.Validators
{
    public class UpdateCourseWeekAllDtoValidator : AbstractValidator<CourseWeekAllDto>
    {
        public UpdateCourseWeekAllDtoValidator()
        {
            Include(new ICourseWeekAllDtoValidator());

            RuleFor(b => b.WeekID).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
