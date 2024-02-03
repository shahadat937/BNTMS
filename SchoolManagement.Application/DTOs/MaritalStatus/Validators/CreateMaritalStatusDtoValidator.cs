using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaritalStatus.Validators 
{
    public class CreateMaritalStatusDtoValidator : AbstractValidator<CreateMaritalStatusDto>
    {
        public CreateMaritalStatusDtoValidator() 
        {
            Include(new IMaritalStatusDtoValidator());
        }
    }
} 
