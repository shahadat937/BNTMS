using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EducationalInstitutions.Validators
{
    public class UpdateEducationalInstitutionDtoValidator : AbstractValidator<EducationalInstitutionDto>
    {
        public UpdateEducationalInstitutionDtoValidator()
        {
            Include(new IEducationalInstitutionDtoValidator()); 

            RuleFor(p => p.EducationalInstitutionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
