using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecQuestionName.Validators
{
    public class UpdateTdecQuestionNameDtoValidator : AbstractValidator<TdecQuestionNameDto>
    {
        public UpdateTdecQuestionNameDtoValidator()
        {
            Include(new ITdecQuestionNameDtoValidator());

            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
