using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FinancialSanction.Validators
{
    public class CreateFinancialSanctionDtoValidator : AbstractValidator<CreateFinancialSanctionDto>
    {
        public CreateFinancialSanctionDtoValidator()  
        {
            Include(new IFinancialSanctionDtoValidator()); 
        }
    }
}
