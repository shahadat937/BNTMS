using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSemesterDurations.Validators
{
    public class CreateBnaSemesterDurationDtoValidator:AbstractValidator<CreateBnaSemesterDurationDto>
    {
        public CreateBnaSemesterDurationDtoValidator() 
        { 
            Include(new IBnaSemesterDurationDtoValidator());
        }
    }
}
 