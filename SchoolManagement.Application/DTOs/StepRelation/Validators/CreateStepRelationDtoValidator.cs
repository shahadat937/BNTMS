using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.StepRelation.Validators
{
    public class CreateStepRelationDtoValidator : AbstractValidator<CreateStepRelationDto>
    {
        public CreateStepRelationDtoValidator()
        {
            Include(new IStepRelationDtoValidator());
        }
    }
}
