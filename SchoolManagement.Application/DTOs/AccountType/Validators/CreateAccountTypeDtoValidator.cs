using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AccountType.Validators
{
    public class CreateAccountTypeDtoValidator : AbstractValidator<CreateAccountTypeDto>
    {
        public CreateAccountTypeDtoValidator()  
        {
            Include(new IAccountTypeDtoValidator()); 
        }
    }
}
