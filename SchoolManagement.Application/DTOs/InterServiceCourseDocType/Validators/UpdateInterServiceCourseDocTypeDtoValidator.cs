using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseDocType.Validators
{
    public class UpdateInterServiceCourseDocTypeDtoValidator : AbstractValidator<InterServiceCourseDocTypeDto>
    {
        public UpdateInterServiceCourseDocTypeDtoValidator()
        {
            Include(new IInterServiceCourseDocTypeDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
