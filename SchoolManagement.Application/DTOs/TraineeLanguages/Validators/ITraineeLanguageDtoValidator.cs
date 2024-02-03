using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeLanguages.Validators
{
    public class ITraineeLanguageDtoValidator : AbstractValidator<ITraineeLanguageDto>
    { 
        public ITraineeLanguageDtoValidator()
        {
            //RuleFor(p => p.TraineeLanguageName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
