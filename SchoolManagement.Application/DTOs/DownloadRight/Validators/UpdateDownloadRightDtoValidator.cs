using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DownloadRight.Validators
{
    public class UpdateDownloadRightDtoValidator : AbstractValidator<DownloadRightDto>
    {
        public UpdateDownloadRightDtoValidator()
        {
            Include(new IDownloadRightDtoValidator());

            RuleFor(p => p.DownloadRightId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
