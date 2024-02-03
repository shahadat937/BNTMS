using FluentValidation;
using SchoolManagement.Application.DTOs.ParentRelative;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ParentRelative.Validators
{
    public class IParentRelativeDtoValidator : AbstractValidator<IParentRelativeDto>
    {
        public IParentRelativeDtoValidator()
        {
            RuleFor(p => p.TraineeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.RelationTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            //RuleFor(p => p.MaritalStatusId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            //RuleFor(p => p.NationalityId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            //RuleFor(p => p.ReligionId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            //RuleFor(p => p.CasteId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull();

            RuleFor(p => p.OccupationId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            //RuleFor(p => p.NameInFull)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        } 
    }
}
