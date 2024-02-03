using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SaylorBranch.Validators
{
    public class UpdateSaylorBranchDtoValidator : AbstractValidator<SaylorBranchDto>
    {
        public UpdateSaylorBranchDtoValidator()
        {
            Include(new ISaylorBranchDtoValidator());

            RuleFor(b => b.SaylorBranchId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

