using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EducationalInstitutions.Validators
{
    public class CreateEducationalInstitutionDtoValidator:AbstractValidator<CreateEducationalInstitutionDto>
    {
        public CreateEducationalInstitutionDtoValidator() 
        {  
            Include(new IEducationalInstitutionDtoValidator());
        }
    }
}
 