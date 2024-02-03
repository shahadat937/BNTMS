using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EducationalQualification.Validators
{
    public class UpdateEducationalQualificationDtoValidator : AbstractValidator<EducationalQualificationDto>
    {
        public UpdateEducationalQualificationDtoValidator()
        {
            Include(new IEducationalQualificationDtoValidator());

            RuleFor(p => p.EducationalQualificationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
