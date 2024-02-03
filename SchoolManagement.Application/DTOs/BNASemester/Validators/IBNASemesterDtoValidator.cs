using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSemester.Validators
{
    public class IBnaSemesterDtoValidator : AbstractValidator<IBnaSemesterDto>
    { 
        public IBnaSemesterDtoValidator()
        {
            //RuleFor(p => p.BoardId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull();

            RuleFor(p => p.SemesterName)
                .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
