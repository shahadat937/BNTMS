using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GameSport.Validators
{
    public class CreateGameSportDtoValidator : AbstractValidator<CreateGameSportDto>
    {
        public CreateGameSportDtoValidator()
        {
            Include(new IGameSportDtoValidator());
        }
    }
}
