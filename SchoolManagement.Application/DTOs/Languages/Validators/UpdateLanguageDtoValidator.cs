using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Languages.Validators
{
    public class UpdateLanguageDtoValidator : AbstractValidator<LanguageDto>
    {
        public UpdateLanguageDtoValidator()
        {
            Include(new ILanguageDtoValidator());

            RuleFor(p => p.LanguageId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
