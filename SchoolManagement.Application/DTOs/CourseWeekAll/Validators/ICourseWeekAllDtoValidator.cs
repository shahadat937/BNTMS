using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.CourseWeekAll.Validators
{
    public class ICourseWeekAllDtoValidator : AbstractValidator<ICourseWeekAllDto>
    {
        public ICourseWeekAllDtoValidator()
        {
            RuleFor(b => b.WeekName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
