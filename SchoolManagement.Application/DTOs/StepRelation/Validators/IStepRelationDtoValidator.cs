using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.StepRelation.Validators
{
    public class IStepRelationDtoValidator : AbstractValidator<IStepRelationDto>
    {
        public IStepRelationDtoValidator()
        {
            RuleFor(p => p.StepRelationType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
