using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.Question.Validators
{
    public class UpdateQuestionDtoValidator : AbstractValidator<QuestionDto>
    {
        public UpdateQuestionDtoValidator()
        {
            Include(new IQuestionDtoValidator());

            RuleFor(p => p.QuestionId).NotNull().WithMessage("{PropertyName} must be present");

            //RuleFor(p => p.QuestionTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
