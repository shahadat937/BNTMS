using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.QuestionType.Validators
{
    public class CreateQuestionTypeDtoValidator : AbstractValidator<CreateQuestionTypeDto>
    {
        public CreateQuestionTypeDtoValidator()
        {
            Include(new IQuestionTypeDtoValidator());
        }
    }
}
