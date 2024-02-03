
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuestionName.Validators
{
   public class CreateTdecQuestionNameDtoValidator : AbstractValidator<CreateTdecQuestionNameDto>
    {
        public CreateTdecQuestionNameDtoValidator()
        {
            Include(new ITdecQuestionNameDtoValidator());
        }
    }
}
