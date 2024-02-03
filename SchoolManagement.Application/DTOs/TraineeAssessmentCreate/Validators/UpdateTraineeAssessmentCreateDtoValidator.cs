using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeAssessmentCreate.Validators
{
    public class UpdateTraineeAssessmentCreateDtoValidator : AbstractValidator<TraineeAssessmentCreateDto>
    {
        public UpdateTraineeAssessmentCreateDtoValidator()
        {
            Include(new ITraineeAssessmentCreateDtoValidator());


            RuleFor(p => p.TraineeAssessmentCreateId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
