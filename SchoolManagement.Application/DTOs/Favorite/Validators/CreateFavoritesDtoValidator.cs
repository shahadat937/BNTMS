using FluentValidation;
using SchoolManagement.Application.DTOs.Favorites;
using SchoolManagement.Application.DTOs.Favorites.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Favorite.Validators
{
    public class CreateFavoritesDtoValidator:AbstractValidator<CreateFavoritesDto>
    {
        public CreateFavoritesDtoValidator() 
        { 
            Include(new IFavoritesDtoValidator());
        }
    }
}
