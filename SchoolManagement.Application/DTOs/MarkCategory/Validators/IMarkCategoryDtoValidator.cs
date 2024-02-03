using FluentValidation;

namespace SchoolManagement.Application.DTOs.MarkCategory.Validators
{
    public class IMarkCategoryDtoValidator : AbstractValidator<IMarkCategoryDto>
    {
        public IMarkCategoryDtoValidator()
        {
            //RuleFor(p => p.TypeName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
