using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeLanguages.Validators
{
    public class CreateTraineeLanguageDtoValidator:AbstractValidator<CreateTraineeLanguageDto>
    {
        public CreateTraineeLanguageDtoValidator() 
        { 
            Include(new ITraineeLanguageDtoValidator());
        }
    }
}
