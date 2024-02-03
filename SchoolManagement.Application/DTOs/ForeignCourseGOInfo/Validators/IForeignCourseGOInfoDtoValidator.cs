using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseGOInfo.Validators
{
    public class IForeignCourseGOInfoDtoValidator : AbstractValidator<IForeignCourseGOInfoDto>
    {
        public IForeignCourseGOInfoDtoValidator()
        {
            //RuleFor(c => c.DocumentName)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
