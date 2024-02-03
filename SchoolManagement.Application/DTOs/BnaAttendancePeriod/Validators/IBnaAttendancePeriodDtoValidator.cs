using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaAttendancePeriod.Validators
{
    public class IBnaAttendancePeriodDtoValidator : AbstractValidator<IBnaAttendancePeriodDto>
    { 
        public IBnaAttendancePeriodDtoValidator()
        {
            //RuleFor(p => p.BoardId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull();

            RuleFor(p => p.PeriodName)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
