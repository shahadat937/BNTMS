using FluentValidation;

namespace SchoolManagement.Application.DTOs.AllowanceCategory.Validators
{
   public class CreateAllowanceCategoryDtoValidator: AbstractValidator<CreateAllowanceCategoryDto>
    {
        public CreateAllowanceCategoryDtoValidator()
        {
            Include(new IAllowanceCategoryDtoValidator());
        }
    }
}
