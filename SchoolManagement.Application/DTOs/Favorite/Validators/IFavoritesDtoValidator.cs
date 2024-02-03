using FluentValidation;
using SchoolManagement.Application.DTOs.CodeValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Favorites.Validators 
{
    public class IFavoritesDtoValidator : AbstractValidator<IFavoritesDto>
    {
        public IFavoritesDtoValidator()
        {
            RuleFor(p => p.TraineeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.FavoritesTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
