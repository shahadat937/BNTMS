using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeNomination.Validators
{
    public class UpdateTraineeNominationDtoValidator : AbstractValidator<TraineeNominationDto>
    {
        public UpdateTraineeNominationDtoValidator()
        {
            Include(new ITraineeNominationDtoValidator());

            //RuleFor(p => p.CourseDurationId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.CourseNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.TraineeId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.TraineeCourseStatusId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.WithdrawnDocId).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
