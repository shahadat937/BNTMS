using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.OnlineLibrary.Validators
{
    public class CreateOnlineLibraryDtoValidator : AbstractValidator<CreateOnlineLibraryDto>
    {
        public CreateOnlineLibraryDtoValidator()
        {
            Include(new IOnlineLibraryDtoValidator());
        }
    }
}
