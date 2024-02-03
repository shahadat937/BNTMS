using FluentValidation;

namespace SchoolManagement.Application.DTOs.MarkType.Validators
{
    public class CreateMarkTypeDtoValidator : AbstractValidator<CreateMarkTypeDto>
    {
        public CreateMarkTypeDtoValidator() 
        {
            Include(new IMarkTypeDtoValidator());
        }
    }
} 
