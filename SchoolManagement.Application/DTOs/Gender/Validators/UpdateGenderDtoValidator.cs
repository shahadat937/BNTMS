using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Gender.Validators
{
    
    public class UpdateGenderDtoValidator : AbstractValidator<GenderDto>
        {
        public UpdateGenderDtoValidator()
        {
            Include(new IGenderDtoValidator());

            RuleFor(p => p.GenderId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
