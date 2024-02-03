using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ExamPeriodTypes.Validators
{
    public class UpdateExamPeriodTypeDtoValidator : AbstractValidator<ExamPeriodTypeDto>
    {
        public UpdateExamPeriodTypeDtoValidator()
        {
            Include(new IExamPeriodTypeDtoValidator());

            RuleFor(b => b.ExamPeriodTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

