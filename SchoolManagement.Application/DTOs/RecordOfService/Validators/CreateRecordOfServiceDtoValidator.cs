using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RecordOfService.Validators
{
    public class CreateRecordOfServiceDtoValidator:AbstractValidator<CreateRecordOfServiceDto>
    {
        public CreateRecordOfServiceDtoValidator() 
        { 
            Include(new IRecordOfServiceDtoValidator());
        }
    }
}
