
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.UserManual.Validators
{
   public class CreateUserManualDtoValidator : AbstractValidator<CreateUserManualDto>
    {
        public CreateUserManualDtoValidator()
        {
            Include(new IUserManualDtoValidator());
        }
    }
}
