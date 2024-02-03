using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Election.Validators
{
    public class CreateElectionDtoValidator : AbstractValidator<CreateElectionDto>
    {
        public CreateElectionDtoValidator()
        {
            Include(new IElectionDtoValidator());
        }
    }
}
