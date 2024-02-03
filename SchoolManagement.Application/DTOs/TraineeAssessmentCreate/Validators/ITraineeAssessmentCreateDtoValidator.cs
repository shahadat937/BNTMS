using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeAssessmentCreate.Validators
{
    public class ITraineeAssessmentCreateDtoValidator : AbstractValidator<ITraineeAssessmentCreateDto>
    {
        public ITraineeAssessmentCreateDtoValidator()
        {
            //RuleFor(p => p.TraineeAssessmentCreateName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            //RuleFor(p => p.DistrictId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

            
        }
    }
}
