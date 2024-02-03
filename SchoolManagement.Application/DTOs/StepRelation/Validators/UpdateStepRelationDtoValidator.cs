using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.StepRelation.Validators
{
    
    public class UpdateStepRelationDtoValidator : AbstractValidator<StepRelationDto>
        {
        public UpdateStepRelationDtoValidator()
        {
            Include(new IStepRelationDtoValidator());

            RuleFor(p => p.StepRelationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
