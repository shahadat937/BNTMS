using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassTestType.Validators
{
    public class CreateBnaClassTestTypeDtoValidator : AbstractValidator<CreateBnaClassTestTypeDto>
    {
        public CreateBnaClassTestTypeDtoValidator()
        {
            Include(new IBnaClassTestTypeDtoValidator());
        }
    }
}
