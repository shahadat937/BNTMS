using FluentValidation;
using SchoolManagement.Application.DTOs.CourseWeekAll.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BnaClassPeriod.Validators
{
    public class UpdateBnaClassPeriodDtoValidator : AbstractValidator<BnaClassPeriodDto>
    {
        public UpdateBnaClassPeriodDtoValidator()
        {
            Include(new IBnaClassPeriodDtoValidator());

            RuleFor(b => b.BnaClassPeriodId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}