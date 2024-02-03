using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeLanguages.Validators
{
    public class UpdateTraineeLanguageDtoValidator : AbstractValidator<TraineeLanguageDto>
    {
        public UpdateTraineeLanguageDtoValidator()
        {
            Include(new ITraineeLanguageDtoValidator()); 

            RuleFor(p => p.TraineeLanguageId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
