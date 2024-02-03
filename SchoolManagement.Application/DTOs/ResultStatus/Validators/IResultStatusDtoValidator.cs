using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ResultStatus.Validators
{
    public class IResultStatusDtoValidator : AbstractValidator<IResultStatusDto>
    {
        public IResultStatusDtoValidator()
        {
            RuleFor(b => b.ResultStatusName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
