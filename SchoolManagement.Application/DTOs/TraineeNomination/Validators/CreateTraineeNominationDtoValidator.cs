using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation; 

namespace SchoolManagement.Application.DTOs.TraineeNomination.Validators
{
    public class CreateTraineeNominationDtoValidator : AbstractValidator<CreateTraineeNominationDto>
    {
        public CreateTraineeNominationDtoValidator()
        {
            Include(new ITraineeNominationDtoValidator());
        }
    }
}
