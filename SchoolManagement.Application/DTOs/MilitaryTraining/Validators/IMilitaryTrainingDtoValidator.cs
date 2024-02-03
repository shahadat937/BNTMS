using FluentValidation;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MilitaryTraining.Validators
{
    public class IMilitaryTrainingDtoValidator : AbstractValidator<IMilitaryTrainingDto>
    {
        public IMilitaryTrainingDtoValidator()
        {
            RuleFor(p => p.TraineeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

           
        }
    }
}
