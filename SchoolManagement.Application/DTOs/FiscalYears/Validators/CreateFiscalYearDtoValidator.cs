using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FiscalYears.Validators
{
    public class CreateFiscalYearDtoValidator : AbstractValidator<CreateFiscalYearDto>
    {
        public CreateFiscalYearDtoValidator()
        {
            Include(new IFiscalYearDtoValidator());
        }
    }
}
 