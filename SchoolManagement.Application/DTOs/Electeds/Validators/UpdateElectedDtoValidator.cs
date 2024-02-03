using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Electeds.Validators
{
    public class UpdateElectedDtoValidator : AbstractValidator<ElectedDto>
    {
        public UpdateElectedDtoValidator() 
        {
            Include(new IElectedDtoValidator()); 

            RuleFor(p => p.ElectedId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
