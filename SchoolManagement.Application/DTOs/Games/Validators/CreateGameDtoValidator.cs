using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Games.Validators
{
    public class CreateGameDtoValidator:AbstractValidator<CreateGameDto>
    {
        public CreateGameDtoValidator() 
        { 
            Include(new IGameDtoValidator());
        }
    }
}
