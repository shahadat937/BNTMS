using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DownloadRight.Validators
{
    public class IDownloadRightDtoValidator : AbstractValidator<IDownloadRightDto>
    {
        public IDownloadRightDtoValidator()
        {
            RuleFor(b => b.DownloadRightName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
