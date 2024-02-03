using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SaylorSubBranch.Validators
{
    public class CreateSaylorSubBranchDtoValidator : AbstractValidator<CreateSaylorSubBranchDto>
    {
        public CreateSaylorSubBranchDtoValidator()  
        {
            Include(new ISaylorSubBranchDtoValidator()); 
        }
    }
}
