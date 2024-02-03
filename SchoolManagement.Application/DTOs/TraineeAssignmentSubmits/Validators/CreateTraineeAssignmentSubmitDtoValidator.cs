
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeAssignmentSubmits.Validators
{ 
   public class CreateTraineeAssignmentSubmitDtoValidator : AbstractValidator<CreateTraineeAssignmentSubmitDto>
    {
        public CreateTraineeAssignmentSubmitDtoValidator()
        {
            Include(new ITraineeAssignmentSubmitDtoValidator());
        }
    }
}
