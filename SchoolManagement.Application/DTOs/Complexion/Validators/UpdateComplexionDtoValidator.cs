using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Complexion.Validators
{
    public class UpdateComplexionDtoValidator : AbstractValidator<ComplexionDto>
    {
        public UpdateComplexionDtoValidator()
        {
            Include(new IComplexionDtoValidator());

            RuleFor(p => p.ComplexionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
