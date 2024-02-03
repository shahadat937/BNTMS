using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamMarkRemarks.Validators
{
    public class UpdateExamMarkRemarkDtoValidator : AbstractValidator<ExamMarkRemarkDto>
    {
        public UpdateExamMarkRemarkDtoValidator()
        {
            Include(new IExamMarkRemarkDtoValidator());

            RuleFor(c => c.MarkRemark).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
