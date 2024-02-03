using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseDocType.Validators
{
    public class IForeignCourseDocTypeDtoValidator : AbstractValidator<IForeignCourseDocTypeDto>
    {
        public IForeignCourseDocTypeDtoValidator()
        {
            //RuleFor(b => b.ForeignCourseDocTypeId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
