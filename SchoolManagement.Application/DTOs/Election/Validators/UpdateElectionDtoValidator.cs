using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Election.Validators
{
    public class UpdateElectionDtoValidator : AbstractValidator<ElectionDto>
    {
        public UpdateElectionDtoValidator()
        {
            Include(new IElectionDtoValidator());

            RuleFor(p => p.ElectionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
