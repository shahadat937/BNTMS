using FluentValidation;
using SchoolManagement.Application.DTOs.RecordOfService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RecordOfService.Validators
{
    public class UpdateRecordOfServiceDtoValidator : AbstractValidator<RecordOfServiceDto>
    {
        public UpdateRecordOfServiceDtoValidator()
        {
            Include(new IRecordOfServiceDtoValidator()); 

            RuleFor(p => p.RecordOfServiceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
