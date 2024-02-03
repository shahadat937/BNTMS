using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DefenseType.Validators
{
    public class UpdateDefenseTypeDtoValidator : AbstractValidator<DefenseTypeDto>
    {
        public UpdateDefenseTypeDtoValidator()
        {
            Include(new IDefenseTypeDtoValidator());

            RuleFor(c => c.DefenseTypeName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
