using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SaylorRank.Validators
{
    public class CreateSaylorRankDtoValidator : AbstractValidator<CreateSaylorRankDto>
    {
        public CreateSaylorRankDtoValidator()  
        {
            Include(new ISaylorRankDtoValidator()); 
        }
    }
}
