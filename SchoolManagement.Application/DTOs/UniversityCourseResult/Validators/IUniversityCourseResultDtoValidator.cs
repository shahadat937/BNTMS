using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.UniversityCourseResult.Validators
{
    public class IUniversityCourseResultDtoValidator : AbstractValidator<IUniversityCourseResultDto>
    {
        public IUniversityCourseResultDtoValidator()
        { 
            RuleFor(p => p.AchievedTotalCredit)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            
        }
    }
}
