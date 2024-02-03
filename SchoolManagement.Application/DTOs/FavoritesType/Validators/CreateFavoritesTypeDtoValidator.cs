using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FavoritesType.Validators
{
    public class CreateFavoritesTypeDtoValidator : AbstractValidator<CreateFavoritesTypeDto>
    {
        public CreateFavoritesTypeDtoValidator()
        {
            Include(new IFavoritesTypeDtoValidator());
        }
    }
}
