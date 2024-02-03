using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentCreate.Validators
{
    public class CreateTraineeAssessmentCreateDtoValidator : AbstractValidator<CreateTraineeAssessmentCreateDto>
    {
        public CreateTraineeAssessmentCreateDtoValidator()
        {
            Include(new ITraineeAssessmentCreateDtoValidator());
        }
    }
}
