using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.KindOfSubjects.Validators 
{
    public class IKindOfSubjectDtoValidator : AbstractValidator<IKindOfSubjectDto>
    {
        public IKindOfSubjectDtoValidator()
        {
            RuleFor(p => p.KindOfSubjectName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
