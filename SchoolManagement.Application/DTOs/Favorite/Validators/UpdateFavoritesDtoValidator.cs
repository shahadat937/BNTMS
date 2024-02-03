using FluentValidation;
using SchoolManagement.Application.DTOs.CodeValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Favorites.Validators 
{
    public class UpdateFavoritesDtoValidator : AbstractValidator<FavoritesDto>
    {
        public UpdateFavoritesDtoValidator()
        {
            Include(new IFavoritesDtoValidator()); 

            RuleFor(p => p.FavoritesId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
