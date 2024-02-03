using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingObjective.Validators
{
    public class UpdateTrainingObjectiveDtoValidator : AbstractValidator<TrainingObjectiveDto>
    {
        public UpdateTrainingObjectiveDtoValidator()
        {
            Include(new ITrainingObjectiveDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
