using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReasonType.Validators
{
    public class CreateReasonTypeDtoValidator : AbstractValidator<CreateReasonTypeDto>
    {
        public CreateReasonTypeDtoValidator()
        {
            Include(new IReasonTypeDtoValidator());
        }
    }
}
