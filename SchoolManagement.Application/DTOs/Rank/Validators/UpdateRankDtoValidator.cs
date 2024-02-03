using FluentValidation;
using SchoolManagement.Application.DTOs.Rank;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank.Validators
{
    public class UpdateRankDtoValidator : AbstractValidator<RankDto>
    {
        public UpdateRankDtoValidator()
        {
            Include(new IRankDtoValidator());

            RuleFor(p => p.RankId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
