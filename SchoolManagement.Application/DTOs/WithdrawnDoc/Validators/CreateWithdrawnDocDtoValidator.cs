using FluentValidation;

namespace SchoolManagement.Application.DTOs.WithdrawnDoc.Validators
{
    public class CreateWithdrawnDocDtoValidator:AbstractValidator<CreateWithdrawnDocDto>
    {
        public CreateWithdrawnDocDtoValidator()
        {
            Include(new IWithdrawnDocDtoValidator());
        }
    }
}
