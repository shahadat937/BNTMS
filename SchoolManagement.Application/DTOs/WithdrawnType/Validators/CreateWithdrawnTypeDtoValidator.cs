using FluentValidation;

namespace SchoolManagement.Application.DTOs.WithdrawnType.Validators
{
   public class CreateWithdrawnTypeDtoValidator: AbstractValidator<CreateWithdrawnTypeDto>
    {
        public CreateWithdrawnTypeDtoValidator()
        {
            Include(new IWithdrawnTypeDtoValidator());
        }
    }
}
