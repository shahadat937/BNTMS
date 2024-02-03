using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SaylorBranch.Validators
{
    public class CreateSaylorBranchDtoValidator : AbstractValidator<CreateSaylorBranchDto>
    {
        public CreateSaylorBranchDtoValidator()  
        {
            Include(new ISaylorBranchDtoValidator()); 
        }
    }
}
