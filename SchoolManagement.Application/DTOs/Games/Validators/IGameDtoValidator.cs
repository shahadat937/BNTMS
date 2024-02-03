using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Games.Validators
{
    public class IGameDtoValidator : AbstractValidator<IGameDto>
    {
        public IGameDtoValidator()
        {
            RuleFor(p => p.GameName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
