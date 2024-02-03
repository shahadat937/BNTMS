using FluentValidation;

namespace SchoolManagement.Application.DTOs.AllowanceCategory.Validators
{
    public class UpdateAllowanceCategoryDtoValidator: AbstractValidator<AllowanceCategoryDto>
    {
        public UpdateAllowanceCategoryDtoValidator()
        {
            Include(new IAllowanceCategoryDtoValidator());

            //RuleFor(c => c.AllowanceCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
