using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentMark.Validators
{
    public class CreateTraineeAssessmentMarkDtoValidator : AbstractValidator<CreateTraineeAssessmentMarkDto>
    {
        public CreateTraineeAssessmentMarkDtoValidator()
        {
            Include(new ITraineeAssessmentMarkDtoValidator());
        }
    }
}
