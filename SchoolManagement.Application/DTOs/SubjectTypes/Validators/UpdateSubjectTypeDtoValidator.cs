using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectTypes.Validators
{
    public class UpdateSubjectTypeDtoValidator : AbstractValidator<SubjectTypeDto>
    { 
        public UpdateSubjectTypeDtoValidator()
        {
            Include(new ISubjectTypeDtoValidator());

            RuleFor(b => b.SubjectTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
