using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamType.Validators
{
    public class UpdateExamTypeDtoValidator : AbstractValidator<ExamTypeDto>
    {
        public UpdateExamTypeDtoValidator()
        {
            Include(new IExamTypeDtoValidator());

            RuleFor(c => c.ExamTypeName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
