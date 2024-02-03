using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank.Validators
{
    public class IRankDtoValidator : AbstractValidator<IRankDto>
    {
        public IRankDtoValidator()
        {
            //RuleFor(p => p.BoardId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            RuleFor(p => p.RankName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
