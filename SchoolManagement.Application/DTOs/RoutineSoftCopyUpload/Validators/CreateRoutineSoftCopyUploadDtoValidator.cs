using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.RoutineSoftCopyUpload.Validators
{
    public class CreateRoutineSoftCopyUploadDtoValidator : AbstractValidator<CreateRoutineSoftCopyUploadDto>
    {
        public CreateRoutineSoftCopyUploadDtoValidator()
        {
            Include(new IRoutineSoftCopyUploadDtoValidator());
        }
    }
}
