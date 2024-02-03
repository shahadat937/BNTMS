using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeVisitedAboard.Validators
{
    public class UpdateTraineeVisitedAboardDtoValidator : AbstractValidator<TraineeVisitedAboardDto>
    {
        public UpdateTraineeVisitedAboardDtoValidator()
        {
            Include(new ITraineeVisitedAboardDtoValidator());

            RuleFor(p => p.TraineeVisitedAboardId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.CountryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
