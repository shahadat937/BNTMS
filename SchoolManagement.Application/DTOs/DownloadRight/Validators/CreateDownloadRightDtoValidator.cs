using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DownloadRight.Validators
{
    public class CreateDownloadRightDtoValidator : AbstractValidator<CreateDownloadRightDto>
    {
        public CreateDownloadRightDtoValidator()
        {
            Include(new IDownloadRightDtoValidator());
        }
    }
}
