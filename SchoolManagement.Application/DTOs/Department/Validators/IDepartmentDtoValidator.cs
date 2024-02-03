using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Department.Validators
{
    public class IDepartmentDtoValidator : AbstractValidator<IDepartmentDto>
    { 
        public IDepartmentDtoValidator()
        {
            //RuleFor(p => p.BoardId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull();

            //RuleFor(p => p.DepartmentName)
            //    .NotEmpty().WithMessage("{Propertyname} is required.").MaximumLength(150).WithMessage("{Propertyname} must not exceed {ComparisonValue} characters.");
        }
    }
}
