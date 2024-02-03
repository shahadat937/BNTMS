using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ResultStatus.Validators
{
    public class CreateResultStatusDtoValidator : AbstractValidator<CreateResultStatusDto>
    {
        public CreateResultStatusDtoValidator()
        {
            Include(new IResultStatusDtoValidator());
        }
    }
}
