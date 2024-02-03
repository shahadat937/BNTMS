using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeAssissmentGroup.Validators
{
    public class CreateTraineeAssissmentGroupDtoValidator : AbstractValidator<CreateTraineeAssissmentGroupDto>
    {
        public CreateTraineeAssissmentGroupDtoValidator()
        {
            Include(new ITraineeAssissmentGroupDtoValidator());
        }
    }
}
