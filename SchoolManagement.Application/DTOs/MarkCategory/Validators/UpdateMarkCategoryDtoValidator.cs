using FluentValidation;
namespace SchoolManagement.Application.DTOs.MarkCategory.Validators
{
    public class UpdateMarkCategoryDtoValidator : AbstractValidator<MarkCategoryDto>
    {
        public UpdateMarkCategoryDtoValidator() 
        {
            Include(new IMarkCategoryDtoValidator());

            RuleFor(p => p.MarkCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}