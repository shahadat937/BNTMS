using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GameSport.Validators
{
    public class UpdateGameSportDtoValidator : AbstractValidator<GameSportDto>
    {
        public UpdateGameSportDtoValidator()
        {
            Include(new IGameSportDtoValidator());

            RuleFor(p => p.GameSportId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
