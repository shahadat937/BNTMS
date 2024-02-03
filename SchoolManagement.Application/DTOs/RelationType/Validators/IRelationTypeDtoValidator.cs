using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.RelationType.Validators
{
    public class IRelationTypeDtoValidator : AbstractValidator<IRelationTypeDto>
    {
        public IRelationTypeDtoValidator()
        {
            RuleFor(p => p.RelationTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
