using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Languages.Validators
{ 
    public class ILanguageDtoValidator : AbstractValidator<ILanguageDto>
    {
        public ILanguageDtoValidator()
        {
            RuleFor(p => p.LanguageName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
