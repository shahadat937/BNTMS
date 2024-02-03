using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.SubjectClassifications.Validators
{

    public class UpdateSubjectClassificationDtoValidator : AbstractValidator<SubjectClassificationDto>
    {
        public UpdateSubjectClassificationDtoValidator()
        {
            Include(new ISubjectClassificationDtoValidator());

            RuleFor(p => p.SubjectClassificationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
