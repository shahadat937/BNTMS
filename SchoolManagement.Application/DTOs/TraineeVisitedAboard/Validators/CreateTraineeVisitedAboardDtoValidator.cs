using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeVisitedAboard.Validators
{
    public class CreateTraineeVisitedAboardDtoValidator : AbstractValidator<CreateTraineeVisitedAboardDto>
    {
        public CreateTraineeVisitedAboardDtoValidator()
        {
            Include(new ITraineeVisitedAboardDtoValidator());
        }
    }
}
