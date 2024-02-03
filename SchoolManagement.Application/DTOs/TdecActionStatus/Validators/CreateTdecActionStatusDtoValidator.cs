
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TdecActionStatus.Validators
{
   public class CreateTdecActionStatusDtoValidator : AbstractValidator<CreateTdecActionStatusDto>
    {
        public CreateTdecActionStatusDtoValidator()
        {
            Include(new ITdecActionStatusDtoValidator());
        }
    }
}
