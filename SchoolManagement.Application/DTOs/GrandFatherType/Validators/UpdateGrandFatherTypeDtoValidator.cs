using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.GrandFatherType.Validators
{
    
    public class UpdateGrandFatherTypeDtoValidator : AbstractValidator<GrandFatherTypeDto>
        {
        public UpdateGrandFatherTypeDtoValidator()
        {
            Include(new IGrandFatherTypeDtoValidator());

            RuleFor(p => p.GrandfatherTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
