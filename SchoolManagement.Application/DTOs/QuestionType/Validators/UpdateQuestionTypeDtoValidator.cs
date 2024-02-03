using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.QuestionType.Validators
{
    public class UpdateQuestionTypeDtoValidator : AbstractValidator<QuestionTypeDto>
    {
        public UpdateQuestionTypeDtoValidator()
        {
            Include(new IQuestionTypeDtoValidator());

            RuleFor(b => b.QuestionTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
