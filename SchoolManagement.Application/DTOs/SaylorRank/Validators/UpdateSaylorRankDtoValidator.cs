using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SaylorRank.Validators
{
    public class UpdateSaylorRankDtoValidator : AbstractValidator<SaylorRankDto>
    {
        public UpdateSaylorRankDtoValidator()
        {
            Include(new ISaylorRankDtoValidator());

            RuleFor(b => b.SaylorRankId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

