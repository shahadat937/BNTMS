using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MilitaryTraining.Validators
{
    public class CreateMilitaryTrainingDtoValidator:AbstractValidator<CreateMilitaryTrainingDto>
    {
        public CreateMilitaryTrainingDtoValidator() 
        { 
            Include(new IMilitaryTrainingDtoValidator());
        }
    }
}
