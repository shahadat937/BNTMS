using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EducationalInstitutions.Validators
{
    public class IEducationalInstitutionDtoValidator : AbstractValidator<IEducationalInstitutionDto>
    {
        public IEducationalInstitutionDtoValidator()
        {
            //RuleFor(p => p.EducationalInstitutionName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
