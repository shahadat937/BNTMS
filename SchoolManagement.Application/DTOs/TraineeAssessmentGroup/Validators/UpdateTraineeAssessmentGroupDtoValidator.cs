using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.TraineeAssissmentGroup.Validators
{
    public class UpdateTraineeAssissmentGroupDtoValidator : AbstractValidator<TraineeAssissmentGroupDto>
    {
        public UpdateTraineeAssissmentGroupDtoValidator()
        {
            Include(new ITraineeAssissmentGroupDtoValidator());


            RuleFor(p => p.TraineeAssissmentGroupId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
