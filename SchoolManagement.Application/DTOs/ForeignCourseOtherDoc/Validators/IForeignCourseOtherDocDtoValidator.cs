using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.Validators
{
    public class IForeignCourseOtherDocDtoValidator : AbstractValidator<IForeignCourseOtherDocDto>
    {
        public IForeignCourseOtherDocDtoValidator()
        {
            //RuleFor(c => c.ForeignCourseOtherDocName)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
