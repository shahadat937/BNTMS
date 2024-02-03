﻿
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FiscalYears.Validators
{ 
    public class IFiscalYearDtoValidator : AbstractValidator<IFiscalYearDto>
    {
        public IFiscalYearDtoValidator()
        {
            RuleFor(b => b.FiscalYearName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
