using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.RelationType.Validators
{
    
    public class UpdateRelationTypeDtoValidator : AbstractValidator<RelationTypeDto>
        {
        public UpdateRelationTypeDtoValidator()
        {
            Include(new IRelationTypeDtoValidator());

            RuleFor(p => p.RelationTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
