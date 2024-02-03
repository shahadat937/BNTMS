using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SaylorSubBranch.Validators
{
    public class UpdateSaylorSubBranchDtoValidator : AbstractValidator<SaylorSubBranchDto>
    {
        public UpdateSaylorSubBranchDtoValidator()
        {
            Include(new ISaylorSubBranchDtoValidator());

            RuleFor(b => b.SaylorSubBranchId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

