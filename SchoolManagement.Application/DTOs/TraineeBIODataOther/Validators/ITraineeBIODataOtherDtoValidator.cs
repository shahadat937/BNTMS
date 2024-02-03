using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeBioDataOther.Validators
{
    public class ITraineeBioDataOtherDtoValidator : AbstractValidator<ITraineeBioDataOtherDto>
    {
        public ITraineeBioDataOtherDtoValidator()
        {
            //RuleFor(p => p.PNo)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            //RuleFor(p => p.BNASemesterId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

            
        }
    }
}
