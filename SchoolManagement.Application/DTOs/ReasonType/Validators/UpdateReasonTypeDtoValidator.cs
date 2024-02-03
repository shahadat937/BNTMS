using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReasonType.Validators
{
    public class UpdateReasonTypeDtoValidator : AbstractValidator<ReasonTypeDto>
    {
        public UpdateReasonTypeDtoValidator()
        {
            Include(new IReasonTypeDtoValidator());

            RuleFor(b => b.ReasonTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
