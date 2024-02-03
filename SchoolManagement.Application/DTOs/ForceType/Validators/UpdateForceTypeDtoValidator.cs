using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForceType.Validators
{
    public class UpdateForceTypeDtoValidator : AbstractValidator<ForceTypeDto>
    {
        public UpdateForceTypeDtoValidator()
        {
            Include(new IForceTypeDtoValidator());

            RuleFor(c => c.ForceTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
