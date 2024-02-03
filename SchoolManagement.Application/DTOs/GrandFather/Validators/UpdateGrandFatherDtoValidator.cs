using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GrandFather.Validators
{
    public class UpdateGrandFatherDtoValidator : AbstractValidator<GrandFatherDto>
    {
        public UpdateGrandFatherDtoValidator()
        {
            Include(new IGrandFatherDtoValidator());

            RuleFor(p => p.GrandFatherId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
