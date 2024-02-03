using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Weight.Validators
{
    public class UpdateWeightDtoValidator : AbstractValidator<WeightDto>
    {
        public UpdateWeightDtoValidator()
        {
            Include(new IWeightDtoValidator());

            RuleFor(p => p.WeightId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
