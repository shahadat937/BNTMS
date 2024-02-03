using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMediaTypes.Validators
{
    public class ISocialMediaTypeDtoValidator : AbstractValidator<ISocialMediaTypeDto>
    {
        public ISocialMediaTypeDtoValidator()
        {
            RuleFor(p => p.SocialMediaTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
