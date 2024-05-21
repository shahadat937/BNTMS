using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.UniversityCourseResult.Validators
{
    
    public class UpdateUniversityCourseResultDtoValidator : AbstractValidator<UniversityCourseResultDto>
        {
        public UpdateUniversityCourseResultDtoValidator()
        {
            Include(new IUniversityCourseResultDtoValidator()); 

            RuleFor(p => p.UniversityCourseResultId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
