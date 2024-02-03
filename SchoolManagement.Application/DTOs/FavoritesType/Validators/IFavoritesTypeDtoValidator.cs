
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FavoritesType.Validators
{
    public class IFavoritesTypeDtoValidator : AbstractValidator<IFavoritesTypeDto>
    {
        public IFavoritesTypeDtoValidator()
        {
            RuleFor(b => b.FavoritesTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
