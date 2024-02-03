using FluentValidation;

namespace SchoolManagement.Application.DTOs.MarkCategory.Validators
{
    public class CreateMarkCategoryDtoValidator : AbstractValidator<CreateMarkCategoryDto>
    {
        public CreateMarkCategoryDtoValidator() 
        {
            Include(new IMarkCategoryDtoValidator());
        }
    }
} 
