
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NewEntryEvaluation.Validators
{
   public class CreateNewEntryEvaluationDtoValidator : AbstractValidator<CreateNewEntryEvaluationDto>
    {
        public CreateNewEntryEvaluationDtoValidator()
        {
            Include(new INewEntryEvaluationDtoValidator());
        }
    }
}
