
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingObjective.Validators
{
   public class CreateTrainingObjectiveDtoValidator : AbstractValidator<CreateTrainingObjectiveDto>
    {
        public CreateTrainingObjectiveDtoValidator()
        {
            Include(new ITrainingObjectiveDtoValidator());
        }
    }
}
