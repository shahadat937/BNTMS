using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeAssessmentMark.Validators
{
    public class UpdateTraineeAssessmentMarkDtoValidator : AbstractValidator<TraineeAssessmentMarkDto>
    {
        public UpdateTraineeAssessmentMarkDtoValidator()
        {
            Include(new ITraineeAssessmentMarkDtoValidator());


            RuleFor(p => p.TraineeAssessmentMarkId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
