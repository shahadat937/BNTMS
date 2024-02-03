using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaServiceType.Validators
{
    public class CreateBnaServiceTypeDtoValidator : AbstractValidator<CreateBnaServiceTypeDto>
    {
        public CreateBnaServiceTypeDtoValidator()
        {
            Include(new IBnaServiceTypeDtoValidator());
        }
    }
}
