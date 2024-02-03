using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Complexion.Validators
{
    public class CreateComplexionDtoValidator : AbstractValidator<CreateComplexionDto>
    {
        public CreateComplexionDtoValidator()
        {
            Include(new IComplexionDtoValidator());
        }
    }
}
