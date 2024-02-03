using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FavoritesType.Validators
{
    public class UpdateFavoritesTypeDtoValidator : AbstractValidator<FavoritesTypeDto>
    {
        public UpdateFavoritesTypeDtoValidator()
        {
            Include(new IFavoritesTypeDtoValidator());

            RuleFor(b => b.FavoritesTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
