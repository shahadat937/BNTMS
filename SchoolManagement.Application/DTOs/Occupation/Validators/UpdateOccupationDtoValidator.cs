using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Occupation.Validators
{
    public class UpdateOccupationDtoValidator : AbstractValidator<OccupationDto>
    {
        public UpdateOccupationDtoValidator()
        {
            Include(new IOccupationDtoValidator());

            RuleFor(c => c.OccupationName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
