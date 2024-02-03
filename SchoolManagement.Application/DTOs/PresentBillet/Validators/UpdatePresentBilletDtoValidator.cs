using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentBillet.Validators
{
    
    public class UpdatePresentBilletDtoValidator : AbstractValidator<PresentBilletDto>
        {
        public UpdatePresentBilletDtoValidator()
        {
            Include(new IPresentBilletDtoValidator());

            RuleFor(p => p.PresentBilletId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
