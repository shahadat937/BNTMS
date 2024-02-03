using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentBillet.Validators
{
    public class CreatePresentBilletDtoValidator : AbstractValidator<CreatePresentBilletDto>
    {
        public CreatePresentBilletDtoValidator()
        {
            Include(new IPresentBilletDtoValidator());
        }
    }
}
