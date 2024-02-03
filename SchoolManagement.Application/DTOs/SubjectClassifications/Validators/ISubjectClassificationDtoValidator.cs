using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SubjectClassifications.Validators
{
    public class ISubjectClassificationDtoValidator : AbstractValidator<ISubjectClassificationDto>
    {
        public ISubjectClassificationDtoValidator()
        {
            RuleFor(p => p.SubjectClassificationName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
