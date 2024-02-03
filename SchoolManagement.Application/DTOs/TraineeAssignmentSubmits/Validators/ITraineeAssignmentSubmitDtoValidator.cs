using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeAssignmentSubmits.Validators
{ 
    public class ITraineeAssignmentSubmitDtoValidator : AbstractValidator<ITraineeAssignmentSubmitDto>
    {
        public ITraineeAssignmentSubmitDtoValidator()
        {
            //RuleFor(c => c.TraineeAssignmentSubmitName)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
