using FluentValidation;
using SchoolManagement.Application.DTOs.RecordOfService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RecordOfService.Validators
{
    public class IRecordOfServiceDtoValidator : AbstractValidator<IRecordOfServiceDto>
    {
        public IRecordOfServiceDtoValidator()
        {
            RuleFor(p => p.TraineeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

           
        }
    }
}
