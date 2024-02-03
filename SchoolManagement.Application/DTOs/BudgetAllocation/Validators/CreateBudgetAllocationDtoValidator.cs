using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetAllocation.Validators
{
    public class CreateBudgetAllocationDtoValidator : AbstractValidator<CreateBudgetAllocationDto>
    {
        public CreateBudgetAllocationDtoValidator() 
        {
            Include(new IBudgetAllocationDtoValidator());
        }
    }
} 
