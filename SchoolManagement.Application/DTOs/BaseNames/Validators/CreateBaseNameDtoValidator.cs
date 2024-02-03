using FluentValidation;

namespace SchoolManagement.Application.DTOs.BaseNames.Validators
{
    public class CreateBaseNameDtoValidator:AbstractValidator<CreateBaseNameDto>
    {
        public CreateBaseNameDtoValidator() 
        { 
            Include(new IBaseNameDtoValidator());
        }
    }
}
