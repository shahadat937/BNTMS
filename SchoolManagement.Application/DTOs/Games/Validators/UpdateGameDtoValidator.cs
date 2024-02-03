using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Games.Validators
{
    public class UpdateGameDtoValidator : AbstractValidator<GameDto>
    {
        public UpdateGameDtoValidator()
        {
            Include(new IGameDtoValidator()); 

            RuleFor(p => p.GameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
