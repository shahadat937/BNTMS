using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseBudgetAllocation.Validators
{
    public class CreateCourseBudgetAllocationDtoValidator : AbstractValidator<CreateCourseBudgetAllocationDto>
    {
        public CreateCourseBudgetAllocationDtoValidator() 
        {
            Include(new ICourseBudgetAllocationDtoValidator());
        }
    }
} 
