using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoursePlan.Validators
{
    public class UpdateCoursePlanDtoValidator : AbstractValidator<CoursePlanDto>
    {
        public UpdateCoursePlanDtoValidator()
        {
            Include(new ICoursePlanDtoValidator());

            RuleFor(c => c.CoursePlanName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
