using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Nationality.Validators
{
    public class UpdateNationalityDtoValidator : AbstractValidator<NationalityDto>
    {
        public UpdateNationalityDtoValidator()
        {
            Include(new INationalityDtoValidator());

            RuleFor(p => p.NationalityId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
