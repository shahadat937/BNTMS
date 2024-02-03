using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NewEntryEvaluation.Validators
{
    public class UpdateNewEntryEvaluationDtoValidator : AbstractValidator<NewEntryEvaluationDto>
    {
        public UpdateNewEntryEvaluationDtoValidator()
        {
            Include(new INewEntryEvaluationDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
