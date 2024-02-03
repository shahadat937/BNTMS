using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UtofficerType.Validators
{
    public class UpdateUtofficerTypeDtoValidator : AbstractValidator<UtofficerTypeDto>
    {
        public UpdateUtofficerTypeDtoValidator()
        {
            Include(new IUtofficerTypeDtoValidator());

            RuleFor(p => p.UtofficerTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
