using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseDocType.Validators
{
    public class UpdateForeignCourseDocTypeDtoValidator : AbstractValidator<ForeignCourseDocTypeDto>
    {
        public UpdateForeignCourseDocTypeDtoValidator()
        {
            Include(new IForeignCourseDocTypeDtoValidator());

            RuleFor(p => p.ForeignCourseDocTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
