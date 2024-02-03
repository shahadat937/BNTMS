using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.FailureStatus.Validators
{
    public class CreateFailureStatusDtoValidator : AbstractValidator<CreateFailureStatusDto>
    {
        public CreateFailureStatusDtoValidator()
        {
            Include(new IFailureStatusDtoValidator());
        }
    }
}
