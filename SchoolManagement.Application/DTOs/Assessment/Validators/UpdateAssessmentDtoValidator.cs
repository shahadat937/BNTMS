using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Assessment.Validators
{
    public class UpdateAssessmentDtoValidator : AbstractValidator<AssessmentDto>
    {
        public UpdateAssessmentDtoValidator()
        {
            Include(new IAssessmentDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
